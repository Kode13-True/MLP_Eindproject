using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_DbLibrary.Seeding;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLP_TestLibrary.Extensions;

namespace MLP_TestLibrary.LessonController
{
    [TestFixture]
    public class CreateLessonTests
    {
        [TestCase(5, LessonLevel.Novice, 25, "2021-6-6 15:00", "2021-6-6 16:00", 1)]
        [TestCase(6, LessonLevel.Intermediate, 50, "2021-6-6 15:00", "2021-6-6 16:00", 2)]
        public void CreateLessons_Succeeds(int teacherId, LessonLevel lessonLevel, decimal price, string startString, string stopString, int locationId)
        {
            //Arrange
            var start = DateTime.Parse(startString);
            var stop = DateTime.Parse(stopString);
            var testItem = new CreateLessonDTO
            {
                LessonLevel = lessonLevel,
                Price = price,
                Start = start,
                Stop = stop,
                LocationId = locationId
            };
            using(var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }
           
            //Act
            var response = TestFixture.Client.PostJson($"api/Lesson/CreateLesson/{teacherId}", testItem);
            Lesson lesson = null;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                lesson = db.Lessons.Where(x => x.TeacherId == teacherId && x.Price == price && x.Start == start && x.Stop == stop).FirstOrDefault();
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(lesson is not null, "Saved in Db");
            });
        }
    }
}

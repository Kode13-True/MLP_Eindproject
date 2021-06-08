using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_DbLibrary.Seeding;
using MLP_TestLibrary.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_TestLibrary.LessonController
{
    [TestFixture]
    public class GetOneLessonTests
    {
        [TestCase(1)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(21)]
        public void GetOneLesson_Succeeds(int lessonId) 
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);

            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Lesson/GetOne/{lessonId}").Result;
            var content = response.GetContent<ResponseLessonDTO>();

            Lesson lesson;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                lesson = db.Lessons.Where(x => x.Id == lessonId).FirstOrDefault();
            }

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(lesson.Id == content.Id, "Id is correct");
            });
        }
    }
}

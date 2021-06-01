using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.DTO.RatingDTO;
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

namespace MLP_TestLibrary.StudentController
{
    [TestFixture]
    public class GiveRatingTests
    {
        [TestCase(3, 10, 3)]
        public void GiveRating_Succeeds(int lessonId, int personId, int rating)
        {
            //Arrange

            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }
            var testItem = new GiveRatingDTO 
            {
                LessonId = lessonId,
                TeacherId = personId,
                Rating = rating,
            };
            //Act
            var response = TestFixture.Client.PutJson($"api/student/RateTeacher", testItem);
            var lessonContent = response.GetContent<ResponseLessonDTO>();
            Lesson lesson;
            Teacher teacher;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                lesson = db.Lessons.Find(lessonId);
                teacher = db.Teachers.Find(personId);
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(lesson.Completed == true, "Completed lesson in Db");
                Assert.That(teacher.Rating > 0, "Rating Saved in Db");
                Assert.That(teacher.RatingCount > 0, "Rating Saved in Db");
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_DbLibrary.Seeding;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_TestLibrary.LessonController
{
    [TestFixture]
    public class CancelLessonTests
    {
        [TestCase(4)]
        [TestCase(7)]
        [TestCase(13)]
        [TestCase(18)]
        public void Cancel_Lesson_Succeeds(int lessonId)
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Lesson/CancelLesson/{lessonId}").Result;
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
                Assert.That(lesson.StudentId is null, "lesson is cancelled");
            });
        }
    }
}

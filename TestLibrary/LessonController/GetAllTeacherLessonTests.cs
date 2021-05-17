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
    public class GetAllTeacherLessonTests
    {
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        public void GetAllTeacherLessons_Succeeds_Count(int teacherId)
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Lesson/GetAllTeacherLessons/{teacherId}").Result;
            var content = response.GetContent<List<ResponseLessonDTO>>();
            var count = content.Count;

            List<Lesson> lessons;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                lessons = db.Lessons.Where(x => x.TeacherId == teacherId).ToList();
            }
            
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(count == lessons.Count, "Count List");
            });
        }
    }
}

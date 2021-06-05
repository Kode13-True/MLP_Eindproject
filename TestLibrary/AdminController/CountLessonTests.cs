using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Seeding;
using MLP_TestLibrary.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_TestLibrary.AdminController
{
    [TestFixture]
    public class CountLessonTests
    {
        [TestCase]
        public void CountLessons_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync("api/Admin/GetLessonNumbers").Result;
            var responseArray = response.GetContent<int[]>();
            int[] lessonNumbers = new int[3];
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                lessonNumbers = new int[] 
                { 
                    db.Lessons.Where(x => x.Start > DateTime.Now).Count(),
                    db.Lessons.Where(x => x.StudentId == null).Where(x => x.Start > DateTime.Now).Count(),
                    db.Lessons.Where(x => x.StudentId != null).Where(x => x.Start > DateTime.Now).Count() 
                };
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode");
                Assert.That(lessonNumbers[0] == responseArray[0], "Count Total Future Lessons Correct");
                Assert.That(lessonNumbers[1] == responseArray[1], "Count UnBooked future Lessons Correct");
                Assert.That(lessonNumbers[2] == responseArray[2], "Count Booked Future Lessons Correct");
            });
        }
    }
}

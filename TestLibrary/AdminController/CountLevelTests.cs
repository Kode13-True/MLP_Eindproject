using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

namespace MLP_TestLibrary.AdminController
{
    [TestFixture]
    public class CountLevelTests
    {
        [TestCase]
        public void CountLevels_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync("api/Admin/GetLevelNumbers").Result;
            var responseArray = response.GetContent<int[]>();
            int[] levelNumbers = new int[3];
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                levelNumbers = new int[] {db.Lessons.Where(x => x.LessonLevel == LessonLevel.Novice).Count(), 
                                            db.Lessons.Where(x => x.LessonLevel == LessonLevel.Intermediate).Count(), 
                                            db.Lessons.Where(x => x.LessonLevel == LessonLevel.Expert).Count() };
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode");
                Assert.That(levelNumbers[0] == responseArray[0], "Count Novice Level Correct");
                Assert.That(levelNumbers[1] == responseArray[1], "Count Intermediate Level Correct");
                Assert.That(levelNumbers[2] == responseArray[2], "Count Expert Level Correct");
            });
        }
    }
}

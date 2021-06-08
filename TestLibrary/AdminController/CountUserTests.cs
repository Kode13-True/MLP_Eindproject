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
    public class CountUserTests
    {
        [TestCase]
        public void CountUsers_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync("api/Admin/GetUserNumbers").Result;
            var responseArray = response.GetContent<int[]>();
            int[] userNumbers = new int[3];
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                userNumbers = new int[] { db.Students.Count() , db.Teachers.Count(), db.Admins.Count() };
                var totalUsers = userNumbers.Sum();
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode");
                Assert.That(userNumbers[0] == responseArray[0], "Count Students Correct");
                Assert.That(userNumbers[1] == responseArray[1], "Count Teachers Correct");
                Assert.That(userNumbers[2] == responseArray[2], "Count Admins Correct");
            });
        }
    }
}

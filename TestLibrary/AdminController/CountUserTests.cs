using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Seeding;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary.AdminController
{
    [TestFixture]
    public class CountUserTests
    {
        [TestCase]
        public void CountUsers_Succeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync("api/Admin/GetNumberOfUsers").Result;
            var userCount = 0;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                userCount += db.Admins.Count();
                userCount += db.Teachers.Count();
                userCount += db.Students.Count();
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode");
                Assert.That(userCount.ToString() == response.Content.ReadAsStringAsync().Result, "Count Correctly");
            });
        }
    }
}

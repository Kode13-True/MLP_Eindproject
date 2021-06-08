using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.PersonDTO;
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
    public class CreateAdminTests
    {
        [TestCase("john.doe@testmail.com", "lk5kfT7uwnU7UYsnf7bZIVu5BoJl1ixSn6eGOmSqh40=", "John","Doe")]

        public void CreateAdmin_Succeeds(string email, string password, string firstName, string lastName)
        {
            //Arrange
            
            var testItem = new CreateAdminDTO
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.PostJson("api/Admin/Create", testItem);
            Admin admin = null;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                admin = db.Admins.Where(x => x.Email == email && x.Password == password && x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(admin is not null, "Saved in Db");
            });

        }
    }
}

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
    class UpdateAdminTests
    {
        [TestCase(4,"jane.doe@testmail.com", "Test1234", "Jane", "Doe")]
        public void UpdateAdmin_Succeeds(int id, string email, string password, string firstName, string lastName)
        {
            //Arrange

            var testItem = new EditAdminDTO
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
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.PutJson($"api/Admin/Update/{id}", testItem);
            Admin admin = null;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                admin = db.Admins.Where(x => x.Id == id).FirstOrDefault();
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

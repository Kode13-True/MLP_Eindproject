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
    public class GetAdminTests
    {
        [TestCase(4)]

        public void GetAdmin_Succeeds(int id)
        {
            //Arrange

            var testItem = new ResponseAdminDTO
            {
                Id = id
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Admin/One/{id}").Result;
            ResponseAdminDTO responseAdmin = response.GetContent<ResponseAdminDTO>();
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
                Assert.That(response.IsSuccessStatusCode, "Completed Succesfully");
                Assert.That(admin.Id == responseAdmin.Id, "Id's are equal");
            });

        }
    }
}

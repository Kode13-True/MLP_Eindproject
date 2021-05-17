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
    class GetAllAdminsTests
    {
        [TestCase]

        public void GetAllAdmins_Succeed()
        {
            // Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync($"api/Admin/GetAll").Result;
            List<ResponseAdminDTO> responseAdmins = response.GetContent<List<ResponseAdminDTO>>();
            var admins = new List<Admin>();
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                admins = db.Admins.ToList();

            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Completed Succesfully");
                Assert.That(responseAdmins.Count == admins.Count, "Equal number of members");
            });
        }

    }
}

using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.LocationDTO;
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

namespace MLP_TestLibrary.LocationController
{
    [TestFixture]
    public class GetAllLocationsTests
    {
        [TestCase]
        public void GetAll_Locations_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Location/GetAll").Result;
            var content = response.GetContent<List<ResponseLocationDTO>>();

            List<Location> locations;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                locations = db.Locations.ToList();
            }

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(locations.Count == content.Count, "List is correct");
            });
        }
    }
}

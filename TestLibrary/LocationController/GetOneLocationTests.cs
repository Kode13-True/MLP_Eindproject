using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.InstrumentDTO;
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
    public class GetOneLocationTests
    {
        [TestCase(2)]
        public void GetOne_Location_Succeeds(int locationId) 
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);

            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Location/GetOne/{locationId}").Result;
            var content = response.GetContent<ResponseInstrumentDTO>();

            Location location;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                location = db.Locations.Where(x => x.Id == locationId).FirstOrDefault();
            }

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(location.Id == content.Id, "Id is correct");
            });
        }
    }
}

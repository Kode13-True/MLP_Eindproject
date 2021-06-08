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
    public class DeleteLocationTests
    {
        [TestCase]
        public void Delete_Location_Succeeds()
        {
            //Arrange
            var locationTestPrep = new CreateLocationDTO { Street = "somethingstreet", Number = "34", Postal = "1684", Township = "Whereneon" };

            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }
            var prepResponse = TestFixture.Client.PostJson("api/Location/Create", locationTestPrep);
            var prepContent = prepResponse.GetContent<ResponseLocationDTO>();

            Location prepLocation;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                prepLocation = db.Locations.Where(x => x.Id == prepContent.Id).FirstOrDefault();
            }

            //Act
            var response = TestFixture.Client.DeleteAsync($"api/Location/Delete/{prepContent.Id}").Result;

            Location location;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                location = db.Locations.Where(x => x.Id == prepContent.Id).FirstOrDefault();
            }
            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(location is null, "location deleted in Db");
            });
        }
    }
}

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
    public class UpdateLocationTests
    {
        [TestCase("Kensington street", "106", "6452", "London")]
        public void Update_Location_Succeeds(string street, string number, string postal, string township)
        {
            //Arrange
            var testItem = new CreateLocationDTO { Street = street, Number = number, Postal = postal, Township = township };
            var locationTestPrep = new CreateLocationDTO { Street = "somethingstreet", Number = "34", Postal = "1684", Township = "Whereneon" };

            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
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
            var response = TestFixture.Client.PutJson($"api/Location/Update/{prepLocation.Id}", testItem);
            var content = response.GetContent<ResponseLocationDTO>();

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
                Assert.That(location.Street == testItem.Street, "street updated in Db");
                Assert.That(location.Number == testItem.Number, "number updated in Db");
                Assert.That(location.Postal == testItem.Postal, "postal updated in Db");
                Assert.That(location.Township == testItem.Township, "township updated in Db");
            });
        }
    }
}

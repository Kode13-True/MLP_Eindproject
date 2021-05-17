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
    public class CreateLocationTests
    {
        [TestCase("Kensington street", "106", "6452", "London")]
        public void Create_Location_Succeeds(string street, string number, string postal, string township)
        {
            //Arrange
            var testItem = new CreateLocationDTO { Street = street, Number = number, Postal = postal, Township = township };

            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.PostJson("api/Location/Create", testItem);
            var content = response.GetContent<ResponseLocationDTO>();

            Location location;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                location = db.Locations.Where(x => x.Id == content.Id).FirstOrDefault();
            }

            //Arrange
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(location is not null, "Saved in Db");
            });
        }
    }
}

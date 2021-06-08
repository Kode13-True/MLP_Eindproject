using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.AlertDTO;
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

namespace MLP_TestLibrary.AlertController
{
    [TestFixture]
    public class GetOneAlertTests
    {
        [TestCase(1)]
        public void GetOne_Alert_Succeeds(int alertId)
        {
                //Arrange
                using (var scope = TestFixture.ServiceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<MLPDbContext>();
                    SeedData.TestDatabaseSeeding(db);
                }

                //Act
                var response = TestFixture.Client.GetAsync($"api/Alert/One/{alertId}").Result;
                var content = response.GetContent<ResponseAlertDTO>();

                Alert alert;
                using (var scope = TestFixture.ServiceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<MLPDbContext>();
                    alert = db.Alerts.Where(x => x.Id == alertId).FirstOrDefault();
                }

                //Assert
                Assert.Multiple(() =>
                {
                    Assert.That(response.IsSuccessStatusCode, "Statuscode");
                    Assert.That(alert.Id == content.Id, "Id is correct");
                });
        }
    }
}

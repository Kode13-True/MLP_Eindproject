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
    public class GetAllAlertsTests
    {
        [TestCase]
        public void GetAll_Alerts_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Alert/GetAll").Result;
            var content = response.GetContent<List<ResponseAlertDTO>>();

            List<Alert> alerts;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                alerts = db.Alerts.ToList();
            }

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(alerts.Count == content.Count, "List is correct");
            });
        }
    }
}

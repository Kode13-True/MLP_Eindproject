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
    public class CreateAlertTests
    {
        [TestCase( AlertType.Cancelled, "Your lesson on 25/04/2021 has been cancelled.", 16)]
        [TestCase( AlertType.Booked, "Your lesson on 13/03/2021 has been booked.", 8)]
        [TestCase( AlertType.Rate, "Your lesson on 22/05/2021 has been rated 4/5.", 7)]
        public void Create_Alert_Succeeds(AlertType alertType, string message, int aimedPersonId)
        {
            //Arrange
            var testItem = new CreateAlertDTO { AlertType = alertType, Message = message, PersonId = aimedPersonId  };

            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.PostJson($"api/Alert/Create", testItem);
            var content = response.GetContent<ResponseAlertDTO>();

            Alert alert;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                alert = db.Alerts.Where(x => x.Id == content.Id).FirstOrDefault();
            }

            //Arrange
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(alert is not null, "Saved in Db");
            });
        }
    }
}

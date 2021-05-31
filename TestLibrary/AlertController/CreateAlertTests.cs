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
        [TestCase( AlertType.Cancelled, "Lesson Got cancelled", 16)]
        [TestCase( AlertType.Booked, "Lesson Got Booked", 16)]
        [TestCase( AlertType.Rate, "Lesson Got Rated", 16)]
        [TestCase( AlertType.Report, "Lesson Got Reported", 16)]
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

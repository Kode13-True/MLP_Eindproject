using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_DbLibrary.Seeding;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_TestLibrary.AlertController
{
    [TestFixture]
    class DeleteAllAlertTests
    {
        [TestCase]
        public void DeleteAlertsById_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);

                var alert1 = new Alert() { AlertType = AlertType.Booked, DOC = DateTime.Now, Message = "", PersonId = 5 };
                db.Add(alert1);
                var alert2 = new Alert() { AlertType = AlertType.Booked, DOC = DateTime.Now, Message = "", PersonId = 5 };
                db.Add(alert2);
                var alert3 = new Alert() { AlertType = AlertType.Booked, DOC = DateTime.Now, Message = "", PersonId = 5 };
                db.Add(alert3);
                var alert4 = new Alert() { AlertType = AlertType.Booked, DOC = DateTime.Now, Message = "", PersonId = 5 };
                db.Add(alert4);
                db.SaveChanges();
            }

            //Act
            var response = TestFixture.Client.DeleteAsync($"api/Alert/DeleteAll/5").Result;

            List<Alert> alert;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                alert = db.Alerts.Where(x => x.PersonId == 5).ToList();
            }
            //Assert

            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(alert.Count is 0, "Alerts deleted in db");
            });
        }
    }
}

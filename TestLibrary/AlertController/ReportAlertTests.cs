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
    public class ReportAlertTests
    {
        [TestCase("We'll test this I guess")]
        public void ReportUser_Succeeds(string message)
        {
            //Arrange
            var testItem = new CreateReportDTO() { Message = message };

            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.PostJson($"api/Alert/Report", testItem);
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

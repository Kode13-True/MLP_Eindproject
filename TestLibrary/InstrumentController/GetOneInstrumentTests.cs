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

namespace MLP_TestLibrary.InstrumentController
{
    [TestFixture]
    public class GetOneInstrumentTests
    {
        [TestCase(12)]
        public void GetOne_Instrument_Succeeds(int instrumentId)
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);

            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Instrument/One/{instrumentId}").Result;
            var content = response.GetContent<ResponseInstrumentDTO>();

            Instrument instrument;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                instrument = db.Instruments.Where(x => x.Id == instrumentId).FirstOrDefault();
            }

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(instrument.Id == content.Id, "Id is correct");
            });
        }
    }
}

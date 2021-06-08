using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

namespace MLP_TestLibrary.AdminController
{
    [TestFixture]
    public class CountInstrumentTests
    {
        [TestCase]
        public void CountInstruments_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync("api/Admin/GetInstrumentNumbers").Result;
            var responseArray = response.GetContent<int[]>();
            int[] styleNumbers = new int[11];
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                styleNumbers = new int[] {db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Vocals).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Piano).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Guitar).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Violin).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Drums).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Saxophone).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Fluit).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Cello).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Clarinet).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Trumpet).Count(),
                                            db.Lessons.Include(x => x.Instrument).Where(x => x.Instrument.InstrumentName == InstrumentName.Harp).Count()
                };
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode");
                Assert.That(styleNumbers[0] == responseArray[0], "Count Instrument Vocals Correct");
                Assert.That(styleNumbers[1] == responseArray[1], "Count Instrument Piano Correct");
                Assert.That(styleNumbers[2] == responseArray[2], "Count Instrument Guitar Correct");
                Assert.That(styleNumbers[3] == responseArray[3], "Count Instrument Violin Correct");
                Assert.That(styleNumbers[4] == responseArray[4], "Count Instrument Drums Correct");
                Assert.That(styleNumbers[5] == responseArray[5], "Count Instrument Saxophone Correct");
                Assert.That(styleNumbers[6] == responseArray[6], "Count Instrument Fluit Correct");
                Assert.That(styleNumbers[7] == responseArray[7], "Count Instrument Cello Correct");
                Assert.That(styleNumbers[8] == responseArray[8], "Count Instrument Clarinet Correct");
                Assert.That(styleNumbers[9] == responseArray[9], "Count Instrument Trumpet Correct");
                Assert.That(styleNumbers[10] == responseArray[10], "Count Instrument Harp Correct");
            });
        }
    }
}

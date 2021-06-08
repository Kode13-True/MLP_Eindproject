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
    public class CountStyleTests
    {
        [TestCase]
        public void CountStyles_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync("api/Admin/GetStyleNumbers").Result;
            var responseArray = response.GetContent<int[]>();
            int[] styleNumbers = new int[5];
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                styleNumbers = new int[] {db.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Classic).Count(), 
                                            db.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Rock).Count(), 
                                            db.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Jazz).Count(),
                                            db.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Pop).Count(),
                                            db.Lessons.Where(x => x.Instrument.InstrumentStyle == InstrumentStyle.Reggae).Count()
                };
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode");
                Assert.That(styleNumbers[0] == responseArray[0], "Count Classic Style Correct");
                Assert.That(styleNumbers[1] == responseArray[1], "Count Rock Style Correct");
                Assert.That(styleNumbers[2] == responseArray[2], "Count Jazz Style Correct");
                Assert.That(styleNumbers[3] == responseArray[3], "Count Pop Style Correct");
                Assert.That(styleNumbers[4] == responseArray[4], "Count Reggae Style Correct");
            });
        }
    }
}

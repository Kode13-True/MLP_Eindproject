using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.InstrumentDTO;
using MLP_DbLibrary.DTO.LessonDTO;
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
    public class DeleteInstrumentTests
    {
        [TestCase]
        public void Delete_Instrument_Succeeds()
        {
            //Arrange
            var testItemInstrument = new CreateInstrumentDTO { InstrumentName = InstrumentName.Clarinet, InstrumentStyle = InstrumentStyle.Classic };

            var testItemLesson = new CreateLessonDTO
            {
                LessonLevel = LessonLevel.Novice,
                Price = 25,
                Start = DateTime.Parse("2021-6-6 15:00"),
                Stop = DateTime.Parse("2021-6-6 16:00"),
                LocationId = 1
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }
            var lessonResponse = TestFixture.Client.PostJson($"api/Lesson/CreateLesson/8", testItemLesson);
            var lessonContent = lessonResponse.GetContent<ResponseLessonDTO>();
            var instrumentCreateResponse = TestFixture.Client.PostJson($"api/Instrument/Create/{lessonContent.Id}", testItemInstrument);

            Lesson lesson;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                lesson = db.Lessons.Where(x => x.Id == lessonContent.Id).Include(x => x.Instrument).FirstOrDefault();
            }
            var instrumentId = lesson.Instrument.Id;
            //Act
            var response = TestFixture.Client.DeleteAsync($"api/Instrument/Delete/{instrumentId}").Result;

            Instrument instrument;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                instrument = db.Instruments.Find(instrumentId);
            }
            

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(instrument is null, "deleted from Db");
            });


            //CleanUp
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                var lessonToRemoveAfterTest = db.Lessons.Find(lessonContent.Id);
                db.Lessons.Remove(lessonToRemoveAfterTest);
                db.SaveChanges();
            }
        }
    }
}

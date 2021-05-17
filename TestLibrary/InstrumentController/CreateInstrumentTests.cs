﻿using Microsoft.EntityFrameworkCore;
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
    public class CreateInstrumentTests
    {
        [TestCase(InstrumentName.Drums, InstrumentStyle.Jazz)]
        [TestCase(InstrumentName.Cello, InstrumentStyle.Reggae)]
        public void Create_Instrument_Succeeds(InstrumentName instrumentName, InstrumentStyle instrumentStyle)
        {
            //Arrange
            var testItem = new CreateInstrumentDTO { InstrumentName = instrumentName, InstrumentStyle = instrumentStyle };

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
                SeedData.DatabaseSeeding(db);
            }
            var lessonResponse = TestFixture.Client.PostJson($"api/Lesson/CreateLesson/8", testItemLesson);
            var content = lessonResponse.GetContent<ResponseLessonDTO>();

            //Act
            var response = TestFixture.Client.PostJson($"api/Instrument/Create/{content.Id}", testItem);

            Lesson lesson;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                lesson = db.Lessons.Where(x => x.Id == content.Id).Include(x => x.Instrument).FirstOrDefault();
            }
            //Arrange
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(lesson.Instrument is not null, "Saved in Db");
            });

        }
    }
}
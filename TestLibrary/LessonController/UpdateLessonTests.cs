using Microsoft.Extensions.DependencyInjection;
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

namespace MLP_TestLibrary.LessonController
{
    [TestFixture]
    public class UpdateLessonTests
    {
        [TestCase(19, "2021-6-6 15:00", "2021-6-6 16:00", 25, LessonLevel.Expert, InstrumentName.Drums, InstrumentStyle.Jazz, "americalaan", "654", "1682", "Zwaagdijk")]
        [TestCase(2, "2021-6-6 15:00", "2021-6-6 16:00", 25, LessonLevel.Expert, InstrumentName.Drums, InstrumentStyle.Jazz, "americalaan", "654", "1682", "Zwaagdijk")]        
        public void Update_Lesson_Succeeds(int lessonId, DateTime start, DateTime stop, decimal price, LessonLevel lessonLevel,
            InstrumentName instrumentName, InstrumentStyle instrumentStyle,
            string street, string number, string postal, string township)
        {
            //Arrange
            var lessonToUpdate = new EditLessonDTO
            {
                //lesson
                Start = start,
                Stop = stop,
                Price = price,
                LessonLevel = lessonLevel,   
                //instrument
                InstrumentName = instrumentName,
                InstrumentStyle = instrumentStyle,
                //location
                Street = street,
                Number = number,
                Postal = postal,
                Township = township,
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.PutJson($"api/Lesson/UpdateLesson/{lessonId}", lessonToUpdate);
            var content = response.GetContent<ResponseLessonDTO>();

            Lesson lesson;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                lesson = db.Lessons.Where(x => x.Id == lessonId).FirstOrDefault();
            }

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(lesson.Start == lessonToUpdate.Start, "Content is updated");
            });
        }
    }
}

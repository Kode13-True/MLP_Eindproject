using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.DTO.SearchDTO;
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

namespace MLP_TestLibrary.SearchController
{
    [TestFixture]
    public class SearchLessonsTests
    {
        [TestCase("Drums", "Rock", "25", "1800", "Woolley")]
        [TestCase("Drums", "Rock", "25", "1800", null)]
        [TestCase("Drums", "Rock", "25", null, "Woolley")]
        [TestCase("Drums", "Rock", "25", null, null)]
        [TestCase("Drums", "Rock", null, "1800", "Woolley")]
        [TestCase("Drums", "Rock", null, "1800", null)]
        [TestCase("Drums", "Rock", null, null, "Woolley")]
        [TestCase("Drums", "Rock", null, null, null)]
        [TestCase("Drums", null, "25", "1800", "Woolley")]
        [TestCase("Drums", null, "25", "1800", null)]
        [TestCase("Drums", null, "25", null, "Woolley")]
        [TestCase("Drums", null, "25", null, null)]
        [TestCase("Drums", null, null, "1800", "Woolley")]
        [TestCase("Drums", null, null, null, "Woolley")]
        [TestCase("Drums", null, null, null, null)]
        [TestCase(null, "Rock", "25", "1800", "Woolley")]
        [TestCase(null, "Rock", "25", "1800", null)]
        [TestCase(null, "Rock", "25", null, "Woolley")]
        [TestCase(null, "Rock", "25", null, null)]
        [TestCase(null, "Rock", null, "1800", null)]
        [TestCase(null, "Rock", null, null, "Woolley")]
        [TestCase(null, "Rock", null, null, null)]
        [TestCase(null, null, "25", "1800", "Woolley")]
        [TestCase(null, null, "25", "1800", null)]
        [TestCase(null, null, "25", null, "Woolley")]
        [TestCase(null, null, "25", null, null)]
        [TestCase(null, null, null, "1800", "Woolley")]
        [TestCase(null, null, null, "1800", null)]
        [TestCase(null, null, null, null, "Woolley")]
        [TestCase(null, null, null, null, null)]
        [TestCase("Drums", null, null, "1800", null)]
        [TestCase(null, "Rock", null, "1800", "Woolley")]


        public void SearchLessons_Succeeds(InstrumentName? instrumentName = null, InstrumentStyle? instrumentStyle = null, decimal? price = null, string postal = "", string teacherName="")
        {
            //Arrange

            var testItem = new SearchLessonDTO
            {
                InstrumentName = instrumentName,
                InstrumentStyle = instrumentStyle,
                Price = price,
                Postal = postal,
                TeacherName = teacherName,
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.PostJson("api/Search/SearchLessons", testItem);
            var content = response.GetContent<List<ResponseLessonDTO>>();
            List<Lesson> lessons = new List<Lesson>();
            lessons = TestFixture.ServiceProvider.Searchfunction( instrumentName, instrumentStyle, price, postal, teacherName);
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(lessons.Count == content.Count, "Lists are equal");
                Assert.That(lessons.Count >= 1 ,"Lists are not empty");
            });

        }
    }
}

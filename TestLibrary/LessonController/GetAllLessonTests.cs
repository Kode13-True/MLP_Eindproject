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
    public class GetAllLessonTests
    {
        [TestCase]
        public void GetAllLessons_Succeeds()
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync("api/Lesson/GetAllUnbooked").Result;
            var content = response.GetContent<List<ResponseLessonDTO>>();
            var count = content.Count;
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(count is not 0, "Count List");
            });
        }
    }
}

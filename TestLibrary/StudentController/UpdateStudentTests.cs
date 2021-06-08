using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.PersonDTO;
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

namespace MLP_TestLibrary.StudentController
{
    [TestFixture]
    class UpdateStudentTests
    {
        [TestCase(14, "kaya.summons@telenet.be", "Kaya", "Summons")]
        public void UpdateStudent_Succeeds(int id, string email, string firstName, string lastName)
        {
            //Arrange

            var testItem = new EditStudentDTO
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.PutJson($"api/Student/Update/{id}", testItem);
            Student student = null;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                student = db.Students.Where(x => x.Id == id).FirstOrDefault();
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(student is not null, "Saved in Db");
            });

        }
    }
}

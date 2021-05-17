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

namespace MLP_TestLibrary.TeacherController
{
    [TestFixture]
    class UpdateTeacherTests
    {
        [TestCase(11, "claire.soto@hotmail.com", "Test1234", "Claire", "Soto", "One-woman-band")]
        public void UpdateTeacher_Succeeds(int id, string email, string password, string firstName, string lastName, string description)
        {
            //Arrange

            var testItem = new EditTeacherDTO
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Description = description,
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.PutJson($"api/Teacher/Update/{id}", testItem);
            Teacher teacher = null;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                teacher = db.Teachers.Where(x => x.Id == id).FirstOrDefault();
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(teacher is not null, "Saved in Db");
            });

        }
    }
}

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
    class GetAllTeachersTests
    {
        [TestCase]

        public void GetAllTeachers_Succeed()
        {
            // Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync($"api/Teacher/GetAll").Result;
            List<ResponseTeacherDTO> responseTeachers = response.GetContent<List<ResponseTeacherDTO>>();
            var teachers = new List<Teacher>();
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                teachers = db.Teachers.ToList();

            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Completed Succesfully");
                Assert.That(responseTeachers.Count == teachers.Count, "Equal number of members");
            });
        }

    }
}

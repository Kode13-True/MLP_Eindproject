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
    class GetAllStudentsTests
    {
        [TestCase]

        public void GetAllStudents_Succeed()
        {
            // Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }
            //Act
            var response = TestFixture.Client.GetAsync($"api/Student/GetAll").Result;
            List<ResponseStudentDTO> responseStudents = response.GetContent<List<ResponseStudentDTO>>();
            var students = new List<Student>();
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                students = db.Students.ToList();

            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Completed Succesfully");
                Assert.That(responseStudents.Count == students.Count, "Equal number of members");
            });
        }

    }
}

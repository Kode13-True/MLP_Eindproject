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
    public class GetStudentTests
    {
        [TestCase(13)]

        public void GetStudent_Succeeds(int id)
        {
            //Arrange

            var testItem = new ResponseStudentDTO
            {
                Id = id
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.GetAsync($"api/Student/One/{id}").Result;
            ResponseStudentDTO responseStudent = response.GetContent<ResponseStudentDTO>();
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
                Assert.That(response.IsSuccessStatusCode, "Completed Succesfully");
                Assert.That(student.Id == responseStudent.Id, "Id's are equal");
            });

        }
    }
}

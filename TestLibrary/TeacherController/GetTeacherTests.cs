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
    public class GetTeacherTests
    {
        [TestCase(6)]

        public void GetTeacher_Succeeds(int id)
        {
            //Arrange

            var testItem = new ResponseTeacherDTO
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
            var response = TestFixture.Client.GetAsync($"api/Teacher/One/{id}").Result;
            ResponseTeacherDTO responseStudent = response.GetContent<ResponseTeacherDTO>();
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
                Assert.That(response.IsSuccessStatusCode, "Completed Succesfully");
                Assert.That(teacher.Id == responseStudent.Id, "Id's are equal");
            });

        }
    }
}

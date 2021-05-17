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
    public class DeleteStudentTests
    {
        [TestCase(18)]
        public void DeleteStudent_Succeeds(int id)
        {
            //Arrange

            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.DeleteAsync($"api/Student/Delete/{id}").Result;
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
                Assert.That(response.IsSuccessStatusCode, "Completed Successfully");
                Assert.That(student is null, "Deleted from Db");
            });
        }
    }
}

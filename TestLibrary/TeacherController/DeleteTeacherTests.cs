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
    public class DeleteTeacherTests
    {
        [TestCase(12)]
        public void DeleteTeacher_Succeeds(int id)
        {
            //Arrange

            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            //Act
            var response = TestFixture.Client.DeleteAsync($"api/Teacher/Delete/{id}").Result;
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
                Assert.That(response.IsSuccessStatusCode, "Completed Successfully");
                Assert.That(teacher is null, "Deleted from Db");
            });
        }
    }
}

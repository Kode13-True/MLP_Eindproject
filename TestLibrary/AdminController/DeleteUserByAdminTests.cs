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

namespace MLP_TestLibrary.AdminController
{
    [TestFixture]
    public class DeleteUserByAdminTests
    {
        [TestCase]
        public void DeleteTeacherByAdmin_Succeeds()
        {
            //Arrange
            var teacher = new Teacher()
            {
                DOC = DateTime.Now,
                Email = "some.some@some.some",
                Password = "test",
                FirstName = "test",
                LastName = "test",
                Description = "test",
                Rating = 3,
                RatingCount = 15
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);

                db.Teachers.Add(teacher);
                db.SaveChanges();
                teacher = db.Teachers.FirstOrDefault(x => x.DOC == teacher.DOC);
            }
            var DeleteUser = new DeleteUserDTO() { Id = teacher.Id, PersonType = PersonType.Teacher };


            //Act
            var response = TestFixture.Client.PutJson($"api/Admin/DeleteUser", DeleteUser);
            Teacher teacherTest;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                teacherTest = db.Teachers.Find(teacher.Id);
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(teacherTest is null, "teacher is Deleted");
            });
        }

        [TestCase]
        public void DeleteStudentByAdmin_Succeeds()
        {
            //Arrange
            var student = new Student()
            {
                DOC = DateTime.Now,
                Email = "some.some@some.some",
                Password = "test",
                FirstName = "test",
                LastName = "test",                
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);

                db.Students.Add(student);
                db.SaveChanges();
                student = db.Students.FirstOrDefault(x => x.DOC == student.DOC);
            }
            var DeleteUser = new DeleteUserDTO() { Id = student.Id, PersonType = PersonType.Student };


            //Act
            var response = TestFixture.Client.PutJson($"api/Admin/DeleteUser", DeleteUser);
            Student studentTest;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                studentTest = db.Students.Find(student.Id);
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(studentTest is null, "student is Deleted");
            });
        }
        [TestCase]
        public void DeleteAdminByAdmin_Succeeds()
        {
            //Arrange
            var admin = new Admin()
            {
                DOC = DateTime.Now,
                Email = "some.some@some.some",
                Password = "test",
                FirstName = "test",
                LastName = "test",                
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.TestDatabaseSeeding(db);

                db.Admins.Add(admin);
                db.SaveChanges();
                admin = db.Admins.FirstOrDefault(x => x.DOC == admin.DOC);
            }
            var DeleteUser = new DeleteUserDTO() { Id = admin.Id, PersonType = PersonType.Admin };


            //Act
            var response = TestFixture.Client.PutJson($"api/Admin/DeleteUser", DeleteUser);
            Admin adminTest;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                adminTest = db.Admins.Find(admin.Id);
            }
            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "Statuscode");
                Assert.That(adminTest is null, "admin is Deleted");
            });
        }
    }
}

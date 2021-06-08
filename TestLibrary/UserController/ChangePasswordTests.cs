using Microsoft.Extensions.DependencyInjection;
using MLP_DbLibrary.DTO.UserDTO;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_DbLibrary.Seeding;
using MLP_TestLibrary.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MLP_TestLibrary.UserController
{
    [TestFixture]
    public class ChangePasswordTests
    {
        

        [TestCase(2, "test1234", "test" )]
        public void ChangePassword_Admin_Succeeds(int id, string oldPassword, string newPassword)
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            var editPwDTO = new EditPasswordDTO
            {
                NewPassword = newPassword,
                OldPassword = oldPassword
            };
            //Act

            var response = TestFixture.Client.PutJson($"api/Admin/UpdatePassword/{id}", editPwDTO);

            Admin admin;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                admin = db.Admins.Find(id);
            }

            var hmacsha256Key = TestFixture.Configuration.GetSection("Keys").GetSection("HMACSHA256").Value;
            var encoding = new ASCIIEncoding();
            Byte[] textBytes = encoding.GetBytes(newPassword);
            Byte[] keyBytes = encoding.GetBytes(hmacsha256Key);
            Byte[] hashBytes;            
            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
            }
            var newHmacPassword = Convert.ToBase64String(hashBytes);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode is correct");
                Assert.That(admin.Password == newHmacPassword, "Password saved correctly");
            });
        }

        [TestCase(17, "test1234", "test")]
        public void ChangePassword_Student_Succeeds(int id, string oldPassword, string newPassword)
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            var editPwDTO = new EditPasswordDTO
            {
                NewPassword = newPassword,
                OldPassword = oldPassword
            };
            //Act

            var response = TestFixture.Client.PutJson($"api/student/UpdatePassword/{id}", editPwDTO);

            Student student;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                student = db.Students.Find(id);
            }

            var hmacsha256Key = TestFixture.Configuration.GetSection("Keys").GetSection("HMACSHA256").Value;
            var encoding = new ASCIIEncoding();
            Byte[] textBytes = encoding.GetBytes(newPassword);
            Byte[] keyBytes = encoding.GetBytes(hmacsha256Key);
            Byte[] hashBytes;
            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
            }
            var newHmacPassword = Convert.ToBase64String(hashBytes);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode is correct");
                Assert.That(student.Password == newHmacPassword, "Password saved correctly");
            });
        }

        [TestCase(9, "test1234", "test")]
        public void ChangePassword_Teacher_Succeeds(int id, string oldPassword, string newPassword)
        {
            //Arrange
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }

            var editPwDTO = new EditPasswordDTO
            {
                NewPassword = newPassword,
                OldPassword = oldPassword
            };
            //Act

            var response = TestFixture.Client.PutJson($"api/teacher/UpdatePassword/{id}", editPwDTO);

            Teacher teacher;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                teacher = db.Teachers.Find(id);
            }

            var hmacsha256Key = TestFixture.Configuration.GetSection("Keys").GetSection("HMACSHA256").Value;
            var encoding = new ASCIIEncoding();
            Byte[] textBytes = encoding.GetBytes(newPassword);
            Byte[] keyBytes = encoding.GetBytes(hmacsha256Key);
            Byte[] hashBytes;
            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
            }
            var newHmacPassword = Convert.ToBase64String(hashBytes);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.IsSuccessStatusCode, "statuscode is correct");
                Assert.That(teacher.Password == newHmacPassword, "Password saved correctly");
            });
        }
    }
}

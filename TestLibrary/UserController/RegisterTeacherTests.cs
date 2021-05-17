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
using System.Text;
using System.Threading.Tasks;

namespace MLP_TestLibrary.UserController
{
    [TestFixture]
    public class RegisterTeacherTests
    {
        [TestCase("johnop.doeop@gmail.com", "test1234", "johnop.doeop@gmail.com", "test1234", "Johnop", "Doeop", true, false)]
        public void Register_Teacher_Succeeds(string emailToLogin, string passwordToLogin, string email, string password, string firstName, string lastName, bool isTeacher, bool isAdmin)
        {
            //Arrange
            var userToLogin = new LoginUserDTO { Email = emailToLogin, Password = passwordToLogin };
            var userToRegister = new RegisterUserDTO
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                IsTeacher = isTeacher,
                IsAdmin = isAdmin
            };
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                SeedData.DatabaseSeeding(db);
            }
            //Act
            var registerResponse = TestFixture.Client.PostJson("api/User/Register", userToRegister);
            Teacher teacher;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                teacher = db.Teachers.Where(x => x.Email == email).FirstOrDefault();
            }

            var loginResponse = TestFixture.Client.PostJson("api/User/LogIn", userToLogin);
            var token = loginResponse.Content.ReadAsStringAsync().Result;

            var authenticateResponse = TestFixture.Client.PostJson("api/User/Authenticate", token);
            var teacherId = authenticateResponse.GetContent<int>();

            var logoutResponse = TestFixture.Client.PostJson("api/User/LogOut", token);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(registerResponse.IsSuccessStatusCode, "Register Statuscode");
                Assert.That(teacher is not null, "Register saved in Db");

                Assert.That(loginResponse.IsSuccessStatusCode, "Login Statuscode");

                Assert.That(authenticateResponse.IsSuccessStatusCode, "Authentication Statuscode");
                Assert.That(teacher.Id == teacherId, "Id is correct after authentication");

                Assert.That(logoutResponse.IsSuccessStatusCode, "Log out Statuscode");
            });
        }
    }
}

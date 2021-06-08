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
    public class AdminUserTests
    {
        [TestCase("john.doe@gmail.com", "test1234", "john.doe@gmail.com", "test1234", "John", "Doe", false, true)]
        public void Register_Admin_Succeeds(string emailToLogin, string passwordToLogin, string email, string password, string firstName, string lastName, bool isTeacher, bool isAdmin)
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
                SeedData.TestDatabaseSeeding(db);
            }
            //Act
            var registerResponse = TestFixture.Client.PostJson("api/User/Register", userToRegister);
            Admin admin;
            using (var scope = TestFixture.ServiceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MLPDbContext>();
                admin = db.Admins.Where(x => x.Email == email).FirstOrDefault();
            }

            var loginResponse = TestFixture.Client.PostJson("api/User/LogIn", userToLogin);
            var token = loginResponse.Content.ReadAsStringAsync().Result;

            var authenticateResponse = TestFixture.Client.PostJson("api/User/Authenticate", token);
            var responseAdmin = authenticateResponse.GetContent<ResponseAuthenticationDTO>();

            var logoutResponse = TestFixture.Client.PostJson("api/User/LogOut", token);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(registerResponse.IsSuccessStatusCode, "Register Statuscode");
                Assert.That(admin is not null, "Register saved in Db");

                Assert.That(loginResponse.IsSuccessStatusCode, "Login Statuscode");

                Assert.That(authenticateResponse.IsSuccessStatusCode, "Authentication Statuscode");
                Assert.That(admin.Id == responseAdmin.Id, "Id is correct after authentication");
                Assert.That(responseAdmin.PersonType == PersonType.Admin, "Correct persontype");

                Assert.That(logoutResponse.IsSuccessStatusCode, "Log out Statuscode");
            });
        }
    }
}

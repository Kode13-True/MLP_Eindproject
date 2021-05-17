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
    public class RegisterUserTestFail
    {
        [TestCase("abubakr.Boone@gmail.com", "Test1234", "Abubakr","Boone", false, false)]
        public void Register_User_Fails_Duplicate_Email(string email, string password, string firstName, string lastName, bool isTeacher, bool isAdmin)
        {
            //Arrange
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
            var response = TestFixture.Client.PostJson("api/User/Register", userToRegister);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode == System.Net.HttpStatusCode.BadRequest, "Statuscode");                
            });
        }
    }
}

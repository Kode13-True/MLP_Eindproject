using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IUserService
    {
        string EncryptTokenForAuthentication(int? id);
        string DecryptTokenForAuthentication(string token);
        string HashForRegistrationAndLogin(string token);
        Task AddTeacherToDb(Teacher teacher);
        Task AddStudentToDb(Student student);
        int? GetUserFromDb(string email, string password);
        Task AddTokenToUser(int? id, string token);
        bool UserExistanceByToken(string token);
        Task AddAdminToDb(Admin admin);
        Task LogUserOut(string token);
        bool CheckEmailAvailability(string email);
    }
}

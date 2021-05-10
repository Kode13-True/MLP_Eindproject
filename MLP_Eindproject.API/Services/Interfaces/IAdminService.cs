using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IAdminService
    {
        Admin CreateAdmin(Admin admin);
        Admin GetAdmin(int personId);
        List<Admin> GetAllAdmins();
        Admin UpdateAdminById(int personIdToEdit, Admin adminEditValue);
        void DeleteAdminById(int personId);
        int GetNumberOfUsers();
    }
}

﻿using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Admin> CreateAdmin(Admin admin);
        Task<Admin> GetAdmin(int personId);
        List<Admin> GetAllAdmins();
        Task<Admin> UpdateAdminById(int personIdToEdit, Admin adminEditValue);
        Task DeleteAdminById(int personId);
        int GetNumberOfUsers();
    }
}
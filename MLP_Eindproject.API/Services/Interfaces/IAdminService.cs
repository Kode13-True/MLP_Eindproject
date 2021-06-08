using MLP_DbLibrary.DTO.PersonDTO;
using MLP_DbLibrary.DTO.UserDTO;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Admin> CreateAdmin(Admin admin);
        Admin GetAdmin(int personId);
        List<Admin> GetAllAdmins();
        Task<Admin> UpdateAdminById(int personIdToEdit, Admin adminEditValue);
        Task DeleteAdminById(int personId);
        int[] GetNumberOfUsers();
        int[] GetNumberOfLessons();
        public int[] GetNumberOfLevels();
        int[] GetNumberOfStyles();
        public int[] GetNumberOfInstruments();
        Task<bool> DeleteUserByAdmin(DeleteUserDTO deleteUserDTO);
        Task<bool> UpdatePassword(int id, EditPasswordDTO editPasswordDTO);
    }
}

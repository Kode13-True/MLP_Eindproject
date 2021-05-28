using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class AdminService : IAdminService
    {
        private readonly MLPDbContext _context;

        public AdminService(MLPDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> CreateAdmin(Admin admin)
        {
            admin.DOC = DateTime.Now;
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
        }
        public async Task<Admin> GetAdmin(int personId)
        {
            var admin = await _context.Admins.FindAsync(personId);
            return admin;
        }

        public List<Admin> GetAllAdmins()
        {
            var listOfAdmins = _context.Admins.ToList();
            return listOfAdmins;
        }

        public int GetNumberOfUsers()
        {
            var NumberOfTeachers = _context.Teachers.Count();
            var NumberOfStudents = _context.Students.Count();
            var NumberOfAdmins = _context.Admins.Count();
            var NumberOfUsers = NumberOfTeachers + NumberOfStudents + NumberOfAdmins;
            return NumberOfUsers;
        }

        public async Task<Admin> UpdateAdminById(int personIdToEdit, Admin adminEditValue)
        {
            var personToEdit = await _context.Admins.FindAsync(personIdToEdit);
            personToEdit.FirstName = adminEditValue.FirstName;
            personToEdit.LastName = adminEditValue.LastName;
            personToEdit.Email = adminEditValue.Email;
            _context.Admins.Update(personToEdit);
            await _context.SaveChangesAsync();
            return personToEdit;
        }

        public async Task DeleteAdminById(int personId)
        {
            var AdminToDelete = _context.Admins.Find(personId);
            _context.Admins.Remove(AdminToDelete);
            await _context.SaveChangesAsync();            
        }
    }
}

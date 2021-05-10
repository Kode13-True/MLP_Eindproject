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

        public Admin CreateAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return admin;
        }
        public Admin GetAdmin(int personId)
        {
            var admin = _context.Admins.FirstOrDefault(t => t.Id == personId);
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

        public Admin UpdateAdminById(int personIdToEdit, Admin adminEditValue)
        {
            var personToEdit = _context.Admins.First(a => a.Id == personIdToEdit);
            personToEdit.FirstName = adminEditValue.FirstName;
            personToEdit.LastName = adminEditValue.LastName;
            personToEdit.Email = adminEditValue.Email;
            _context.Admins.Update(personToEdit);
            _context.SaveChanges();
            return personToEdit;
        }

        public void DeleteAdminById(int personId)
        {
            var AdminToDelete = _context.Admins.Find(personId);
            _context.Admins.Remove(AdminToDelete);
            _context.SaveChanges();
        }
    }
}

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

        public int GetNumberOfUsers()
        {
            var numberOfTeachers = _context.Teachers.Count();
            var numberOfStudents = _context.Students.Count();
            var numberOfAdmins = _context.Admins.Count();
            var numberOfUsers = numberOfTeachers + numberOfStudents + numberOfAdmins;
            return numberOfUsers;
        }
        public int GetNumberOfStudents()
        {
            var numberOfStudents = _context.Students.Count();
            return numberOfStudents;
        }
        public int GetNumberOfTeachers()
        {
            var numberOfTeachers = _context.Teachers.Count();
            return numberOfTeachers;
        }
        public int GetNumberOfAdmins()
        {
            var numberOfAdmins = _context.Admins.Count();
            return numberOfAdmins;
        }
        public int GetNumberOfLessons()
        {
            var numberOfLessons = _context.Lessons.Count();
            return numberOfLessons;
        }
        public int GetNumberOfBookedLessons()
        {
            var numberOfBookedLessons = _context.Lessons.Count();
            return numberOfBookedLessons;
        }
    }
}

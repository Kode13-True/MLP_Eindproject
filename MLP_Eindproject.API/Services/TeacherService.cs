using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MLP_DbLibrary.DTO.UserDTO;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly MLPDbContext _context;
        private readonly string hmacsha256Key;
        public TeacherService(MLPDbContext context, IConfiguration configuration)
        {
            _context = context;
            hmacsha256Key = configuration.GetSection("Keys").GetSection("HMACSHA256").Value;
        }

        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            teacher.DOC = DateTime.Now;
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
        public Teacher GetTeacher(int personId)
        {
            
            return _context.Teachers.Find(personId);
        }

        public List<Teacher> GetAllTeachers()
        {            
            return _context.Teachers.OrderByDescending(t => t.Rating).ToList();
        }

        public async Task<Teacher> UpdateTeacherById(int personIdToEdit, Teacher teacherEditValue)
        {
            var personToEdit = _context.Teachers.Find(personIdToEdit);
            personToEdit.FirstName = teacherEditValue.FirstName;
            personToEdit.LastName = teacherEditValue.LastName;
            personToEdit.Email = teacherEditValue.Email;
            personToEdit.Description = teacherEditValue.Description;
            _context.Teachers.Update(personToEdit);
            await _context.SaveChangesAsync();
            return personToEdit;
        }

        public async Task DeleteTeacherById(int personId)
        {
            var lessons = _context.Lessons.Where(x => x.TeacherId == personId).Include(x => x.Instrument).Include(x => x.Location).ToList();
            foreach(var lesson in lessons)
            {
                _context.Instruments.Remove(lesson.Instrument);
                _context.Lessons.Remove(lesson);
                _context.Locations.Remove(lesson.Location);
            }
            var PersonToDelete = _context.Teachers.Find(personId);
            _context.Teachers.Remove(PersonToDelete);
            await _context.SaveChangesAsync();
        }

        public List<Lesson> GetTeacherLessons(int personId)
        {
            var teacher = _context.Teachers.Include(x => x.Lessons).FirstOrDefault(x=> x.Id == personId);
            var teacherLessons = teacher.Lessons.ToList();
            return teacherLessons;
        }

        public async Task<bool> UpdatePassword(int id, EditPasswordDTO editPasswordDTO)
        {            
            bool passwordCorrect = false;
            var encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(editPasswordDTO.OldPassword);
            Byte[] keyBytes = encoding.GetBytes(hmacsha256Key);
            Byte[] hashBytes;
            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
            {
                hashBytes = hash.ComputeHash(textBytes);
            }
            var oldPassword = Convert.ToBase64String(hashBytes);

            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher.Password == oldPassword)
            {
                passwordCorrect = true;

                textBytes = encoding.GetBytes(editPasswordDTO.NewPassword);
                keyBytes = encoding.GetBytes(hmacsha256Key);
                using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                {
                    hashBytes = hash.ComputeHash(textBytes);
                }
                var newPassword = Convert.ToBase64String(hashBytes);

                teacher.Password = newPassword;
                await _context.SaveChangesAsync();
            }
            return passwordCorrect;
        }

    }
}

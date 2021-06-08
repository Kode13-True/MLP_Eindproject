using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MLP_DbLibrary.DTO.RatingDTO;
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
    public class StudentService : IStudentService
    {
        private readonly MLPDbContext _context;
        private readonly string hmacsha256Key;
        public StudentService(MLPDbContext context, IConfiguration configuration)
        {
            _context = context;
            hmacsha256Key = configuration.GetSection("Keys").GetSection("HMACSHA256").Value;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            student.DOC = DateTime.Now;
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public Student GetStudent(int personId)
        {            
            return _context.Students.Find(personId);
        }

        public List<Student> GetAllStudents()
        {            
            return _context.Students.ToList();
        }

        public async Task<Student> UpdateStudentById(int personIdToEdit, Student studentEditValue)
        {
            var personToEdit = _context.Students.Find(personIdToEdit);
            personToEdit.FirstName = studentEditValue.FirstName;
            personToEdit.LastName = studentEditValue.LastName;
            personToEdit.Email = studentEditValue.Email;
            _context.Students.Update(personToEdit);
            await _context.SaveChangesAsync();
            return personToEdit;
        }

        public async Task DeleteStudentById(int personId)
        {
            var lessons = _context.Lessons.Where(x => x.StudentId == personId).ToList();
            foreach (var lesson in lessons)
            {
                lesson.StudentId = null;
            }
            var PersonToDelete = _context.Students.Find(personId);
            _context.Students.Remove(PersonToDelete);
            await _context.SaveChangesAsync();
        }

        public List<Lesson> GetStudentLessons(int personId)
        {
            var student = _context.Students.Include(x => x.Lessons).FirstOrDefault(x => x.Id == personId);
            var studentLessons = student.Lessons.ToList();
            return studentLessons;
        }

        public async Task<Lesson> GiveRating(GiveRatingDTO giveRatingDTO)
        {
            if (giveRatingDTO is null)
            {
                throw new ArgumentNullException(nameof(giveRatingDTO));
            }

            var teacher = _context.Teachers.Find(giveRatingDTO.TeacherId);
            if(teacher is not null)
            {
                if(teacher.Rating == 0 && teacher.RatingCount != 0) 
                {
                    teacher.RatingCount = 0;
                }                
                if(teacher.Rating != 0 && teacher.RatingCount == 0) 
                {
                    teacher.Rating = 0;
                }
                var totalRating = teacher.Rating * teacher.RatingCount;
                teacher.RatingCount++;
                teacher.Rating = (totalRating + giveRatingDTO.Rating) / teacher.RatingCount;
                teacher.Rating = Math.Round(teacher.Rating, 1);
            }
            var lesson = _context.Lessons.Find(giveRatingDTO.LessonId);
            if(lesson is not null)
            {
                lesson.Completed = true;
            }
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<bool> UpdatePassword(int id, EditPasswordDTO editPasswordDTO)
        {
            if (editPasswordDTO is null)
            {
                throw new ArgumentNullException(nameof(editPasswordDTO));
            }
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

            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student.Password == oldPassword)
            {
                passwordCorrect = true;

                textBytes = encoding.GetBytes(editPasswordDTO.NewPassword);
                keyBytes = encoding.GetBytes(hmacsha256Key);
                using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                {
                    hashBytes = hash.ComputeHash(textBytes);
                }
                var newPassword = Convert.ToBase64String(hashBytes);

                student.Password = newPassword;
                await _context.SaveChangesAsync();
            }
            return passwordCorrect;
        }
    }
}

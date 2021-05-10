using Microsoft.EntityFrameworkCore;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly MLPDbContext _context;

        public StudentService(MLPDbContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            student.DOC = DateTime.Now;
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> GetStudent(int personId)
        {
            var student = await _context.Students.FindAsync(personId);
            return student;
        }

        public List<Student> GetAllStudents()
        {
            var listOfStudents = _context.Students.ToList();
            return listOfStudents;
        }

        public async Task<Student> UpdateStudentById(int personIdToEdit, Student studentEditValue)
        {
            var personToEdit = await _context.Students.FindAsync(personIdToEdit);
            personToEdit.FirstName = studentEditValue.FirstName;
            personToEdit.LastName = studentEditValue.LastName;
            personToEdit.Email = studentEditValue.Email;
            personToEdit.Password = studentEditValue.Password;
            _context.Students.Update(personToEdit);
            await _context.SaveChangesAsync();
            return personToEdit;
        }

        public async Task DeleteStudentById(int personId)
        {
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
    }
}

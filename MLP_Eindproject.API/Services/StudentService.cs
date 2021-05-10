using Microsoft.EntityFrameworkCore;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MLP_Eindproject.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly MLPDbContext _context;

        public StudentService(MLPDbContext context)
        {
            _context = context;
        }

        public Student CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
        public Student GetStudent(int personId)
        {
            var student = _context.Students.FirstOrDefault(t => t.Id == personId);
            return student;
        }

        public List<Student> GetAllStudents()
        {
            var listOfStudents = _context.Students.ToList();
            return listOfStudents;
        }

        public Student UpdateStudentById(int personIdToEdit, Student studentEditValue)
        {
            var personToEdit = _context.Students.First(s => s.Id == personIdToEdit);
            personToEdit.FirstName = studentEditValue.FirstName;
            personToEdit.LastName = studentEditValue.LastName;
            personToEdit.Email = studentEditValue.Email;
            _context.Students.Update(personToEdit);
            _context.SaveChanges();
            return personToEdit;
        }

        public void DeleteStudentById(int personId)
        {
            var PersonToDelete = _context.Students.Find(personId);
            _context.Students.Remove(PersonToDelete);
            _context.SaveChanges();
        }

        public List<Lesson> GetStudentLessons(int personId)
        {
            var student = _context.Students.Include(x => x.Lessons).FirstOrDefault(x => x.Id == personId);
            var studentLessons = student.Lessons.ToList();
            return studentLessons;
        }
    }
}

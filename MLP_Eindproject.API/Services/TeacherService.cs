using Microsoft.EntityFrameworkCore;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MLP_Eindproject.API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly MLPDbContext _context;

        public TeacherService(MLPDbContext context)
        {
            _context = context;
        }

        public Teacher CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }
        public Teacher GetTeacher(int personId)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == personId);
            return teacher;
        }

        public List<Teacher> GetAllTeachers()
        {
            var listOfTeachers = _context.Teachers.ToList();
            return listOfTeachers;
        }

        public Teacher UpdateTeacherById(int personIdToEdit, Teacher teacherEditValue)
        {
            var personToEdit = _context.Teachers.First(t => t.Id == personIdToEdit);
            personToEdit.FirstName = teacherEditValue.FirstName;
            personToEdit.LastName = teacherEditValue.LastName;
            personToEdit.Email = teacherEditValue.Email;
            personToEdit.Description = teacherEditValue.Description;
            personToEdit.Instruments = teacherEditValue.Instruments;
            _context.Teachers.Update(personToEdit);
            _context.SaveChanges();
            return personToEdit;
        }

        public void DeleteTeacherById(int personId)
        {
            var PersonToDelete = _context.Teachers.Find(personId);
            _context.Teachers.Remove(PersonToDelete);
            _context.SaveChanges();
        }

        public List<Lesson> GetTeacherLessons(int personId)
        {
            var teacher = _context.Teachers.Include(x => x.Lessons).FirstOrDefault(x=> x.Id == personId);
            var teacherLessons = teacher.Lessons.ToList();
            return teacherLessons;
        }

        public List<Instrument> GetTeacherInstruments(int personId)
        {
            var teacher = _context.Teachers.Include(x => x.Instruments).FirstOrDefault(x => x.Id == personId);
            var teacherInstruments = teacher.Instruments.ToList();
            return teacherInstruments;
        }
    }
}

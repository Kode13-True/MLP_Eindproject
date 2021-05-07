using Microsoft.EntityFrameworkCore;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class LessonService : ILessonService
    {
        private readonly MLPDbContext _context;
        public LessonService(MLPDbContext context)
        {
            _context = context;
        }

        public async Task AddTeacherToLesson(int teacherId, Lesson lessonFromDb)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x == lessonFromDb);
            lesson.PersonLessons.Add(new PersonLesson { LessonId = lesson.Id, PersonId = teacherId });
            await _context.SaveChangesAsync();
        }

        public async Task BookLesson(int studentId, int lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            lesson.PersonLessons.Add(new PersonLesson { LessonId = lessonId, PersonId = studentId });
            await _context.SaveChangesAsync();
        }

        public async Task<Lesson> CreateLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);            
            await _context.SaveChangesAsync();
            return await _context.Lessons.FirstOrDefaultAsync(x => x == lesson);
        }

        public async Task DeleteLessonById(int id)
        {
            var lessonToDelete = await _context.Lessons.FindAsync(id);
            _context.Remove(lessonToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task EditLesson(int id, Lesson lesson)
        {
            var lessonToEdit = await _context.Lessons.FindAsync(id);
            lessonToEdit.Start = lesson.Start;
            lessonToEdit.Stop = lesson.Stop;
            lessonToEdit.LessonLevel = lesson.LessonLevel;
            await _context.SaveChangesAsync();            
        }

        public List<Lesson> GetAllLessons()
        {
            return _context.Lessons.Include(x => x.PersonLessons).ToList();
        }

        public async Task<Lesson> GetDetailsById(int id)
        {
            return await _context.Lessons.Include(x => x.PersonLessons).ThenInclude(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

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
    public class LessonService : ILessonService
    {
        private readonly MLPDbContext _context;
        public LessonService(MLPDbContext context)
        {
            _context = context;
        }
        public async Task<Lesson> CreateLessonByTeacherId(int teacherId, Lesson lesson)
        {
            lesson.TeacherId = teacherId;
            lesson.DOC = DateTime.Now;
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson> BookLesson(int studentId, int lessonId)
        {
            var lessonToBook = await _context.Lessons.Include(x => x.Location).Include(x => x.Teacher).Include(x => x.Student).Include(x => x.Instrument).FirstOrDefaultAsync(x => x.Id == lessonId);
            lessonToBook.StudentId = studentId;
            lessonToBook.Booked = DateTime.Now;
            await _context.SaveChangesAsync();
            return lessonToBook;
        }
        public async Task<Lesson> CancelLesson(int lessonId)
        {
            var lessonToCancel = await _context.Lessons.Include(x => x.Location).Include(x => x.Teacher).Include(x => x.Student).Include(x => x.Instrument).FirstOrDefaultAsync(x => x.Id == lessonId);
            if(lessonToCancel.Start > DateTime.Now.AddHours(48))
            {
                lessonToCancel.StudentId = null;
                lessonToCancel.Booked = DateTime.MinValue;
                await _context.SaveChangesAsync();
            }
            return lessonToCancel;
        }
        public async Task<Lesson> UpdateLessonByTeacherId(int lessonId, Lesson lesson)
        {
            var lessonToUpdate = await _context.Lessons.Include(x => x.Location).Include(x => x.Teacher).Include(x => x.Student).Include(x => x.Instrument).FirstOrDefaultAsync(x => x.Id == lessonId);
            if (lessonToUpdate.StudentId is null)
            {
                lessonToUpdate.LessonLevel = lesson.LessonLevel;
                lessonToUpdate.LocationId = lesson.LocationId;
                lessonToUpdate.Price = lesson.Price;
                lessonToUpdate.Start = lesson.Start;
                lessonToUpdate.Stop = lesson.Stop;
                await _context.SaveChangesAsync();
            }
            return lessonToUpdate;
        }
        public async Task<Lesson> DeleteLesson(int id)
        {
            var lessonToDelete = await _context.Lessons.FindAsync(id);
            if (lessonToDelete.StudentId is null)
            {
                _context.Remove(lessonToDelete);
                await _context.SaveChangesAsync();
            }
            return lessonToDelete;
        }

        public List<Lesson> GetAllUnbookedLessons()
        {
            return _context.Lessons.Include(x => x.Location).Include(x => x.Teacher).Include(x => x.Student).Include(x => x.Instrument).Where(x => x.StudentId == null).ToList();
        }        
        public List<Lesson> GetAllTeacherLessons(int teacherId)
        {
            return _context.Lessons.Include(x => x.Location).Include(x => x.Teacher).Include(x => x.Student).Include(x => x.Instrument).Where(x => x.TeacherId == teacherId).ToList();
        }
        public List<Lesson> GetAllStudentLessons(int studentId)
        {
            return _context.Lessons.Include(x => x.Location).Include(x => x.Teacher).Include(x => x.Instrument).Where(x => x.StudentId == studentId).ToList();
        }
        public async Task<Lesson> GetOneLessonById(int id)
        {
            return await _context.Lessons.Include(x => x.Location).Include(x => x.Teacher).Include(x => x.Student).Include(x => x.Instrument).FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}

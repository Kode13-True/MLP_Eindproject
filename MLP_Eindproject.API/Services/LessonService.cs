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
        public async Task<Lesson> CreateLessonByTeacherId(int teacherId, Lesson lesson)
        {
            lesson.TeacherId = teacherId;
            lesson.DOC = DateTime.Now;
            lesson.Completed = false;
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<Lesson> BookLesson(int studentId, int lessonId)
        {
            var lessonToBook = _context.Lessons.Include(x => x.Location)
                                                        .Include(x => x.Teacher)
                                                        .Include(x => x.Student)
                                                        .Include(x => x.Instrument)
                                                        .FirstOrDefault(x => x.Id == lessonId);
            if(lessonToBook.StudentId == null)
            {
                lessonToBook.StudentId = studentId;
                lessonToBook.Booked = DateTime.Now;
                await _context.SaveChangesAsync();
                return lessonToBook;
            }
            else
            {
                return null;
            }
           
        }
        public async Task<Lesson> CancelLesson(int lessonId)
        {
            var lessonToCancel = _context.Lessons.Include(x => x.Location)
                                                        .Include(x => x.Teacher)
                                                        .Include(x => x.Student)
                                                        .Include(x => x.Instrument)
                                                        .FirstOrDefault(x => x.Id == lessonId);
            if (lessonToCancel.Start > DateTime.Now.AddHours(48))
            {
                lessonToCancel.StudentId = null;
                lessonToCancel.Booked = DateTime.MinValue;
                await _context.SaveChangesAsync();
            }
            return lessonToCancel;
        }
        public async Task<Lesson> UpdateLessonByTeacherId(int lessonId, EditLessonDTO lesson)
        {
            var lessonToUpdate = _context.Lessons.Include(x => x.Location)
                                                        .Include(x => x.Teacher)
                                                        .Include(x => x.Student)
                                                        .Include(x => x.Instrument)
                                                        .FirstOrDefault(x => x.Id == lessonId);
            if (lessonToUpdate.StudentId is null)
            {
                //lesson
                lessonToUpdate.LessonLevel = lesson.LessonLevel;
                lessonToUpdate.Price = lesson.Price;
                lessonToUpdate.Start = lesson.Start;
                lessonToUpdate.Stop = lesson.Stop;
                //instrument
                lessonToUpdate.Instrument.InstrumentName = lesson.InstrumentName;
                lessonToUpdate.Instrument.InstrumentStyle = lesson.InstrumentStyle;
                //location
                lessonToUpdate.Location.Street = lesson.Street;
                lessonToUpdate.Location.Number = lesson.Number;
                lessonToUpdate.Location.Postal = lesson.Postal;
                lessonToUpdate.Location.Township = lesson.Township;
                
                await _context.SaveChangesAsync();
            }
            return lessonToUpdate;
        }
        public async Task<Lesson> DeleteLesson(int id)
        {
            var lessonToDelete = _context.Lessons.Find(id);
            if (lessonToDelete.StudentId is null)
            {
                _context.Lessons.Remove(lessonToDelete);
                await _context.SaveChangesAsync();
            }
            else if (lessonToDelete.Start > DateTime.Now.AddHours(24))
            {
                _context.Lessons.Remove(lessonToDelete);
                await _context.SaveChangesAsync();
            }
            return lessonToDelete;
        }

        public List<Lesson> GetAllUnbookedLessons()
        {
            return _context.Lessons.Include(x => x.Location)
                                    .Include(x => x.Teacher)
                                    .Include(x => x.Student)
                                    .Include(x => x.Instrument)
                                    .Where(x => x.StudentId == null)
                                    .OrderBy(l => l.Start).ToList();
        }        
        public List<Lesson> GetAllTeacherLessons(int teacherId)
        {
            return _context.Lessons.Include(x => x.Location)
                                    .Include(x => x.Teacher)
                                    .Include(x => x.Student)
                                    .Include(x => x.Instrument)
                                    .Where(x => x.TeacherId == teacherId)
                                    .OrderBy(l => l.Start).ToList();
        }
        public List<Lesson> GetAllStudentLessons(int studentId)
        {
            return _context.Lessons.Include(x => x.Location)
                                    .Include(x => x.Teacher)
                                    .Include(x => x.Instrument)
                                    .Where(x => x.StudentId == studentId)
                                    .OrderBy(l => l.Start).ToList();
        }
        public Lesson GetOneLessonById(int id)
        {
            return _context.Lessons.Include(x => x.Location)
                                            .Include(x => x.Teacher)
                                            .Include(x => x.Student)
                                            .Include(x => x.Instrument)
                                            .FirstOrDefault(x => x.Id == id);
        }


    }
}

using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface ILessonService
    {
        List<Lesson> GetAllUnbookedLessons();
        Lesson GetOneLessonById(int id);
        Task<Lesson> CreateLessonByTeacherId(int teacherId, Lesson lesson);
        Task<Lesson> UpdateLessonByTeacherId(int lessonId, EditLessonDTO lesson);
        Task<Lesson> CancelLesson(int lessonId);
        Task<Lesson> BookLesson(int studentId, int lessonId);
        Task<Lesson> DeleteLesson(int id);
        List<Lesson> GetAllTeacherLessons(int teacherId);
        List<Lesson> GetAllStudentLessons(int studentId);
    }
}

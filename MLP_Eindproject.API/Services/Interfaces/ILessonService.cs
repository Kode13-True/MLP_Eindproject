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
        List<Lesson> GetAllLessons();
        Task<Lesson> GetDetailsById(int id);
        Task<Lesson> CreateLesson(Lesson lesson);
        Task EditLesson(int id, Lesson lesson);
        Task DeleteLessonById(int id);
        Task AddTeacherToLesson(int teacherId, Lesson lessonFromDb);
        Task BookLesson(int studentId, int lessonId);
    }
}

using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> CreateTeacher(Teacher teacher);
        Task<Teacher> GetTeacher(int personId);
        List<Teacher> GetAllTeachers();
        Task<Teacher> UpdateTeacherById(int personIdToEdit, Teacher teacherEditValue);
        Task DeleteTeacherById(int personId);

    }
}

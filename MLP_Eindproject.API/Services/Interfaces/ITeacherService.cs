using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface ITeacherService
    {
        Teacher CreateTeacher(Teacher teacher);
        Teacher GetTeacher(int personId);
        List<Teacher> GetAllTeachers();
        Teacher UpdateTeacherById(int personIdToEdit, Teacher teacherEditValue);
        void DeleteTeacherById(int personId);

    }
}

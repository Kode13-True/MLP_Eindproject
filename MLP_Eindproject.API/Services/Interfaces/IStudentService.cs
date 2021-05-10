using MLP_DbLibrary.Models;
using System.Collections.Generic;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(Student student);
        Student GetStudent(int personId);
        List<Student> GetAllStudents();
        Student UpdateStudentById(int personIdToEdit, Student studentEditValue);
        void DeleteStudentById(int personId);

    }
}
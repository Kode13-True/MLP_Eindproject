using MLP_DbLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateStudent(Student student);
        Task<Student> GetStudent(int personId);
        List<Student> GetAllStudents();
        Task<Student> UpdateStudentById(int personIdToEdit, Student studentEditValue);
        Task DeleteStudentById(int personId);
        List<Lesson> GetStudentLessons(int personId);
    }
}
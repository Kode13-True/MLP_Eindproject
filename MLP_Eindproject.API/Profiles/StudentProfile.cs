using AutoMapper;
using MLP_DbLibrary.DTO.PersonDTO;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<ResponseStudentDTO, Student>().ReverseMap();
            CreateMap<CreateStudentDTO, Student>().ReverseMap();
            CreateMap<EditStudentDTO, Student>().ReverseMap();
        }
    }
}

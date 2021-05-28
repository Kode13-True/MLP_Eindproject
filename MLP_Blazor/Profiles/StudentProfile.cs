using AutoMapper;
using MLP_DbLibrary.DTO.PersonDTO;
using MLP_DbLibrary.VM.PersonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Blazor.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<ResponseStudentDTO, ResponseStudentVM>().ReverseMap();
            CreateMap<EditStudentDTO, EditStudentVM>().ReverseMap();
        }
    }
}

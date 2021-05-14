using AutoMapper;
using MLP_DbLibrary.DTO.PersonDTO;
using MLP_DbLibrary.DTO.UserDTO;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<ResponseTeacherDTO, Teacher>().ReverseMap();
            CreateMap<CreateTeacherDTO, Teacher>().ReverseMap();
            CreateMap<EditTeacherDTO, Teacher>().ReverseMap();
            CreateMap<RegisterUserDTO, Teacher>().ReverseMap();
        }
    }
}

using AutoMapper;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Profiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<CreateLessonDTO, Lesson>().ReverseMap();
            CreateMap<EditLessonDTO, Lesson>().ReverseMap();
        }
    }
}

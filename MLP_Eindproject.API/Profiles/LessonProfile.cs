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
            CreateMap<Lesson, CreateLessonDTO>()               
                .ReverseMap();
            CreateMap<Lesson, ResponseLessonDTO>()
                .ForMember(x => x.Street, x => x.MapFrom(x => x.Location.Street))
                .ForMember(x => x.Number, x => x.MapFrom(x => x.Location.Number))
                .ForMember(x => x.Postal, x => x.MapFrom(x => x.Location.Postal))
                .ForMember(x => x.Township, x => x.MapFrom(x => x.Location.Township))
                .ForMember(x => x.StudentFirstName, x => x.MapFrom(x => x.Student.FirstName))
                .ForMember(x => x.StudentLastName, x => x.MapFrom(x => x.Student.LastName))
                .ForMember(x => x.TeacherFirstName, x => x.MapFrom(x => x.Teacher.FirstName))
                .ForMember(x => x.TeacherLastName, x => x.MapFrom(x => x.Teacher.LastName))
                .ForMember(x => x.TeacherInstruments, x => x.MapFrom(x => x.Teacher.Instruments))
                .ForMember(x => x.TeacherRating, x => x.MapFrom(x => x.Teacher.Rating))
                .ForMember(x => x.TeacherDescription, x => x.MapFrom(x => x.Teacher.Description))
                .ReverseMap();
        }
    }
}

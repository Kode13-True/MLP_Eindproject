using AutoMapper;
using MLP_DbLibrary.DTO.PersonDTO;
using MLP_DbLibrary.VM.PersonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Blazor.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<ResponseTeacherDTO, ResponseTeacherVM>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating.ToString()))
                .ReverseMap();
            CreateMap<EditTeacherDTO, EditTeacherVM>().ReverseMap();
        }
    }
}

using AutoMapper;
using MLP_DbLibrary.DTO.InstrumentDTO;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.DTO.LocationDTO;
using MLP_DbLibrary.VM.LessonVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Blazor.Profiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<ResponseLessonDTO, ResponseLessonVM>().ReverseMap();
            CreateMap<CreateLessonDTO, CreateLessonVM>().ReverseMap();
            CreateMap<CreateInstrumentDTO, CreateLessonVM>().ReverseMap();
            CreateMap<CreateLocationDTO, CreateLessonVM>().ReverseMap();
            CreateMap<EditLessonDTO, EditLessonVM>()
                .ForMember(x => x.Start, x => x.MapFrom(x => x.Start))
                .ForMember(x => x.Stop, x => x.MapFrom(x => x.Stop))
                .ReverseMap();
           
        }
    }
}

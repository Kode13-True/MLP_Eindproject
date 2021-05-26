using AutoMapper;
using MLP_DbLibrary.DTO.LessonDTO;
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
        }
    }
}

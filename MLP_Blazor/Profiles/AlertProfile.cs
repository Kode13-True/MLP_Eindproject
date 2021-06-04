using AutoMapper;
using MLP_DbLibrary.DTO.AlertDTO;
using MLP_DbLibrary.VM.AlertVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Blazor.Profiles
{
    public class AlertProfile : Profile
    {
        public AlertProfile()
        {
            CreateMap<ResponseAlertDTO, ResponseAlertVM>().ReverseMap();
            
        }
    }
}

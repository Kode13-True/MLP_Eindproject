using AutoMapper;
using MLP_DbLibrary.Models;
using MLP_DbLibrary.DTO.AlertDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Profiles
{
    public class AlertProfile : Profile
    {
        public AlertProfile()
        {
            CreateMap<CreateAlertDTO, Alert>().ReverseMap();
            CreateMap<ResponseAlertDTO, Alert>().ReverseMap();

        }
    }
}

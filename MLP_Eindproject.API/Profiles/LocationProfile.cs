using AutoMapper;
using MLP_DbLibrary.DTO.LocationDTO;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile() 
        {
            CreateMap<CreateLocationDTO, Location>().ReverseMap();
            CreateMap<ResponseLocationDTO, Location>().ReverseMap();
        }
    }
}

using AutoMapper;
using MLP_DbLibrary.Models;
using MLP_DbLibrary.DTO.PersonDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
            {
            CreateMap<ResponseAdminDTO, Admin>().ReverseMap();
            CreateMap<CreateAdminDTO, Admin>().ReverseMap();
            CreateMap<EditAdminDTO, Admin>().ReverseMap();
            }
    }
}

﻿using AutoMapper;
using MLP_DbLibrary.DTO.UserDTO;
using MLP_DbLibrary.VM.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Blazor.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDTO, RegisterUserVM>().ReverseMap();
            CreateMap<LoginUserDTO, LoginUserVM>().ReverseMap();
        }
    }
}

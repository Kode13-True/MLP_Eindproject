using AutoMapper;
using MLP_DbLibrary.DTO.PersonDTO;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<ResponsePersonDTO, Person>().ReverseMap();
            CreateMap<CreatePersonDTO, Person>().ReverseMap();
            CreateMap<EditPersonDTO, Person>().ReverseMap();
        }
    }
}

using AutoMapper;
using MLP_DbLibrary.DTO.Instrument;
using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Profiles
{
    public class InstrumentProfile : Profile
    {
        public InstrumentProfile()
        {
            CreateMap<ResponseInstrumentDTO, Instrument>().ReverseMap();
            CreateMap<CreateInstrumentDTO, Instrument>().ReverseMap();
        }
    }
}

using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IInstrumentService
    {
        Instrument CreateInstrument(Instrument instrument);
        Instrument GetInstrument(int instrumentId);
        List<Instrument> GetAllInstruments();
        void DeleteInstrumentById(int instrumentId);
    }
}

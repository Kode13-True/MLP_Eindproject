using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services.Interfaces
{
    public interface IInstrumentService
    {
        Task<Instrument> CreateInstrument(Instrument instrument, int lessonId);
        Instrument GetInstrument(int instrumentId);
        Instrument GetInstrumentByLessonId(int lessonId);
        List<Instrument> GetAllInstruments();
        Task DeleteInstrumentById(int instrumentId);
        
    }
}

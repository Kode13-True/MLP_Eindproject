using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class InstrumentService : IInstrumentService
    {
        private readonly MLPDbContext _context;
        
        public InstrumentService(MLPDbContext context)
        {
            _context = context;
        }
        
        public async Task<Instrument> CreateInstrument(Instrument instrument, int lessonId)
        {
                instrument.LessonId = lessonId;
                _context.Instruments.Add(instrument);
                await _context.SaveChangesAsync();
                return instrument;            
        }

        public Instrument GetInstrument(int instrumentId)
        {                
                return _context.Instruments.Find(instrumentId);
        }

        public Instrument GetInstrumentByLessonId(int lessonId)
        {            
            return _context.Instruments.Where(x => x.LessonId == lessonId).FirstOrDefault();
        }
        public List<Instrument> GetAllInstruments()
        {                
                return _context.Instruments.ToList();
        }

        public async Task DeleteInstrumentById(int instrumentId)
        {
                var InstrumentToDelete = _context.Instruments.Find(instrumentId);
                _context.Instruments.Remove(InstrumentToDelete);
                await _context.SaveChangesAsync();        
        }

       
    }
}

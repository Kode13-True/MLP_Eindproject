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
        
        public async Task<Instrument> CreateInstrument(Instrument instrument, int teacherId)
        {
                instrument.TeacherId = teacherId;
                await _context.Instruments.AddAsync(instrument);
                await _context.SaveChangesAsync();
                return instrument;            
        }

        public async Task<Instrument> GetInstrument(int instrumentId)
        {
                var instrument = await _context.Instruments.FindAsync(instrumentId);
                return instrument;
        }

        public List<Instrument> GetAllInstruments()
        {
                var listOfInstruments = _context.Instruments.ToList();
                return listOfInstruments; 
        }

        public async Task DeleteInstrumentById(int instrumentId)
        {
                var InstrumentToDelete = _context.Instruments.Find(instrumentId);
                _context.Instruments.Remove(InstrumentToDelete);
                await _context.SaveChangesAsync();        
        }
    }
}

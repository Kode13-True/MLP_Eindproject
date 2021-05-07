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
        
        public Instrument CreateInstrument(Instrument instrument)
        {
           
            _context.Instruments.Add(instrument);
            _context.SaveChanges();
            return instrument;            
        }
        public Instrument GetInstrument(int instrumentId)
        {
                var instrument = _context.Instruments.FirstOrDefault(i => i.Id == instrumentId);
                return instrument;
        }

        public List<Instrument> GetAllInstruments()
        {
                var listOfInstruments = _context.Instruments.ToList();
                return listOfInstruments; 
        }

        public void DeleteInstrumentById(int instrumentId)
        {
                var InstrumentToDelete = _context.Instruments.Find(instrumentId);
                _context.Instruments.Remove(InstrumentToDelete);
                _context.SaveChanges();        
        }
    }
}

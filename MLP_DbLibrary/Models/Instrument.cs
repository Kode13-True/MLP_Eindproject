using System.Collections.Generic;

namespace MLP_DbLibrary.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public InstrumentName InstrumentName { get; set; }
        public Style Style { get; set; }
        public List<PersonInstrument> Persons { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
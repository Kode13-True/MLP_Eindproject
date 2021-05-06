using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.Models
{
    public class PersonInstrument
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}

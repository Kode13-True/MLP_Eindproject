using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.Instrument
{
    public class CreateInstrumentDTO
    {
        public InstrumentName InstrumentName { get; set; }
        public InstrumentStyle InstrumentStyle { get; set; }
    }
}

using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO
{
    public class ResponseInstrumentDTO
    {
        public int Id { get; set; }
        public InstrumentName InstrumentName { get; set; }
        public InstrumentStyle InstrumentStyle { get; set; }
    }
}

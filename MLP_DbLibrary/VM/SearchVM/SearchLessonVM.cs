using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.VM.SearchVM
{
    public class SearchLessonVM
    {
        public InstrumentName? InstrumentName { get; set; }
        public InstrumentStyle? InstrumentStyle { get; set; }
        public decimal? Price { get; set; }
        public string Postal { get; set; }
        public string TeacherName { get; set; }
    }
}

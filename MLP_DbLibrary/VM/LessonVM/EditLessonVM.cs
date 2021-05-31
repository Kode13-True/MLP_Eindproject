using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.VM.LessonVM
{
    public class EditLessonVM
    {
        //instruments (CreateDTO)
        public InstrumentName InstrumentName { get; set; }
        public InstrumentStyle InstrumentStyle { get; set; }

        //Lesson (EditDTO)
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public decimal Price { get; set; }
        public LessonLevel LessonLevel { get; set; }

        //Location (CreateDTO)
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postal { get; set; }
        public string Township { get; set; }
    }
}

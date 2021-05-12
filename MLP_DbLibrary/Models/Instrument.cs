using System.Collections.Generic;

namespace MLP_DbLibrary.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public InstrumentName InstrumentName { get; set; }
        public InstrumentStyle InstrumentStyle { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
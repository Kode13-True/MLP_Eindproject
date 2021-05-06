using System;

namespace MLP_DbLibrary.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int TeacherId { get; set; }
        public Person Teacher { get; set; }
        public int StudentId { get; set; }
        public Person Student { get; set; }
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        public Level Level { get; set; }
        public bool Completed { get; set; }
    }
}
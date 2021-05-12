using System;
using System.Collections.Generic;

namespace MLP_DbLibrary.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime DOC { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public int LocationId { get; set; }
        public decimal Price { get; set; }
        public Location Location { get; set; }      
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }  
        public int? StudentId { get; set; }
        public Student Student { get; set; }
        public Instrument Instrument { get; set; }
        public LessonLevel LessonLevel { get; set; }
        public DateTime Booked { get; set; }
        public bool Completed { get; set; }
    }
}
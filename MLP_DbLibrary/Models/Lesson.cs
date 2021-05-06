using System;
using System.Collections.Generic;

namespace MLP_DbLibrary.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public int LocationId { get; set; }
        public decimal Price { get; set; }
        public Location Location { get; set; }       
        public List<PersonLesson> PersonLessons { get; set; }       
        public LessonLevel LessonLevel { get; set; }
        public bool Completed { get; set; }
    }
}
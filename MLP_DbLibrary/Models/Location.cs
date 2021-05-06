using System.Collections.Generic;

namespace MLP_DbLibrary.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postal { get; set; }
        public string Township { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
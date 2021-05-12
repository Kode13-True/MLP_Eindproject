using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.LessonDTO
{
    public class ResponseLessonDTO
    {
        public int Id { get; set; }
        public DateTime DOC { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public decimal Price { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postal { get; set; }
        public string Township { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string InstrumentName { get; set; }
        public string InstrumentStyle { get; set; }
        public string TeacherDescription { get; set; }
        public double TeacherRating { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }        
        public LessonLevel LessonLevel { get; set; }
    }
}

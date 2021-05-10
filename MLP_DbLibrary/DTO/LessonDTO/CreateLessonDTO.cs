using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.LessonDTO
{
    public class CreateLessonDTO
    {           
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public int LocationId { get; set; }
        public decimal Price { get; set; }       
        public LessonLevel LessonLevel { get; set; }
    }
}

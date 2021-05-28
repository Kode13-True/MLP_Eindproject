using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.VM.LessonVM
{
    public class CreateLessonVM
    {

        //LocationVariables

        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Postal { get; set; }
        [Required]
        public string Township { get; set; }

        //InstrumentVariables

        [Required]
        public InstrumentName InstrumentName { get; set; }
        [Required]
        public InstrumentStyle InstrumentStyle { get; set; }

        //LessonVariables
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime Stop { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public LessonLevel LessonLevel { get; set; }
    }
}

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
        //LocationVariables
        [Required]
        [StringLength(50, ErrorMessage = "Street name has a max length of 50 characters.")]
        public string Street { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "Street number has a max length of 6 characters.")]
        public string Number { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "Postal has a max length of 5 characters.")]
        public string Postal { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Township has a max length of 25 characters.")]
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
        [Required]/*Fully reset number, to reset error decimals*/
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "The price can maximally have two decimals!")]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }
        [Required]
        public LessonLevel LessonLevel { get; set; }
    }
}

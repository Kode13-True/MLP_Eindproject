using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.VM.UserVM
{
    public class RegisterUserVM
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 6, ErrorMessage ="Must be between 6 and 25 characters")]
        public string Password { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 6)]
        public string PasswordConfirm { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
    }
}

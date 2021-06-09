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
        [Required(ErrorMessage ="Email is required!")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Email must be a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [StringLength(25, MinimumLength = 6, ErrorMessage =" Password must be between 6 and 25 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Confirm is required!")]        
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "First name must be between 1 and 25 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Last name must be between 1 and 25 characters")]
        public string LastName { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
    }
}

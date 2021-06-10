using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.VM.UserVM
{
    public class EditPasswordVM
    {
        [Required(ErrorMessage = "Old password is required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "New password is required")]
        [StringLength(25, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 25 characters")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        public string ConfirmNewPassword { get; set; }
    }
}

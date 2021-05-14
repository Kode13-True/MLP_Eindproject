using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.UserDTO
{
    public class RegisterUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsTeacher { get; set; }
    }
}

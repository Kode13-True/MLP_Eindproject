using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.PersonDTO
{
    public class ResponsePersonDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
        public double Rating { get; set; }
    }
}

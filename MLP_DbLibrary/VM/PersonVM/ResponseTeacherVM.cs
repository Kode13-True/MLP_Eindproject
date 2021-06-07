using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.VM.PersonVM
{
    public class ResponseTeacherVM
    {
        public int Id { get; set; }
        public DateTime DOC { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.VM.PersonVM
{
    public class ResponseStudentVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DOC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

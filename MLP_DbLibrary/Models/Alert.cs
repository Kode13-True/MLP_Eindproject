using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public DateTime DOC { get; set; }
        public AlertType AlertType { get; set; }
        public string Message { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}

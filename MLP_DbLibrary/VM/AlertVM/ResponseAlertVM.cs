using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.VM.AlertVM
{
    public class ResponseAlertVM
    {
        public int Id { get; set; }
        public AlertType AlertType { get; set; }
        public string Message { get; set; }
        public int PersonId { get; set; }
    }
}

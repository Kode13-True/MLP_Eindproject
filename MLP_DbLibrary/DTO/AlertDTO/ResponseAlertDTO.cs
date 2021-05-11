using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.AlertDTO
{
    public class ResponseAlertDTO
    {
        public AlertType AlertType { get; set; }
        public string Message { get; set; }
        public int PersonId { get; set; }
    }
}

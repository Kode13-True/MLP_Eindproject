using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.UserDTO
{
    public class ResponseAuthenticationDTO
    {
        public int Id { get; set; }
        public PersonType PersonType { get; set; }

    }
}

using MLP_DbLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_Blazor.Models
{
    public class LocalAuthUser
    {
        public int Id { get; set; }
        public PersonType Role { get; set; }
        public string AuthToken { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.DTO.LocationDTO
{
    public class CreateLocationDTO
    {

        public string Street { get; set; }
        public string Number { get; set; }
        public string Postal { get; set; }
        public string Township { get; set; }
    }
}

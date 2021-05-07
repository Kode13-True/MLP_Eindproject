using System.Collections.Generic;
using MLP_DbLibrary.Models;

namespace MLP_DbLibrary.DTO.LocationDTO
{
    public class ResponseLocationDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postal { get; set; }
        public string Township { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}

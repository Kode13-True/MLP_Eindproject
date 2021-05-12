using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.Models
{
    public class Teacher : Person
    {
        public string Description { get; set; }
        public List<Lesson> Lessons { get; set; }
        public double Rating { get; set; }
    }
}

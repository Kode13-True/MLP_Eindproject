using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.Models
{
    public class Student : Person
    {
        public List<Lesson> Lessons { get; set; }
    }
}

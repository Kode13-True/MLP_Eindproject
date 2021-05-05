using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLP_DbLibrary.Models
{
    public class Person
    {/*Id : int
        Email : string
        Password : string
        LastName : string
        FirstName : string
        Location : Location
        Instruments : Dict<Instrument>
        isTeacher : bool
        isAdmin : bool
        Rating : double?
        Lessons : List<Lesson>
*/
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  Location Location { get; set; }
        public List<Instrument> Instruments { get; set; }
        public List<Lesson> Lessons { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsAdmin { get; set; }
        public double Rating { get; set; }
    }
}

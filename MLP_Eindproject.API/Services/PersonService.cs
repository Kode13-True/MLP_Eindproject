using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly MLPDbContext _context;

        public PersonService(MLPDbContext context)
        {
            _context = context;
        }

        public Person CreatePerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person GetPerson(int personId)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == personId);
            return person;
        }

        public List<Person> GetAllPerons()
        {
            var listOfPersons = _context.Persons.ToList();
            return listOfPersons;
        }

        public void DeletePersonById(int personId)
        {
            var PersonToDelete = _context.Persons.Find(personId);
            _context.Persons.Remove(PersonToDelete);
            _context.SaveChanges();
        }
    }
}

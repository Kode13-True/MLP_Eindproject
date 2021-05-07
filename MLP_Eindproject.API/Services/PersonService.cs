using MLP_DbLibrary.MLPContext;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MLP_Eindproject.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly MLPDbContext _context;

        public PersonService(MLPDbContext context)
        {
            _context = context;
        }

        //public Person CreatePerson(Person person)
        //{
        //    _context.Persons.Add(person);
        //    _context.SaveChanges();
        //    return person;
        //}
        //public Person GetPerson(int personId)
        //{
        //    var person = _context.Persons.FirstOrDefault(p => p.Id == personId);
        //    return person;
        //}

        //public List<Person> GetAllPerons()
        //{
        //    var listOfPersons = _context.Persons.ToList();
        //    return listOfPersons;
        //}

        //public Person UpdatePersonById(int personIdToEdit, Person personEditValue)
        //{

        //    var personToEdit = _context.Persons.First(p => p.Id == personIdToEdit);
        //    personToEdit.FirstName = personEditValue.FirstName;
        //    personToEdit.LastName = personEditValue.LastName;
        //    personToEdit.Email = personEditValue.Email;
        //    personToEdit.Description = personEditValue.Description;
        //    personToEdit.PersonInstruments = personEditValue.PersonInstruments;
        //    _context.Persons.Update(personToEdit);
        //    _context.SaveChanges();
        //    return personToEdit;
        //}

        //public void DeletePersonById(int personId)
        //{
        //    var PersonToDelete = _context.Persons.Find(personId);
        //    _context.Persons.Remove(PersonToDelete);
        //    _context.SaveChanges();
        //}
    }
}

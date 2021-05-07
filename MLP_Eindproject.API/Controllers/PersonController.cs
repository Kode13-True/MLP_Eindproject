using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO.PersonDTO;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MLP_Eindproject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        //// POST api/<PersonController>
        //[HttpPost("Create")]
        //public ActionResult<Person> CreateNewInstrument(CreatePersonDTO createPersonDTO)
        //{
        //    var newPerson = _mapper.Map<Person>(createPersonDTO);
        //    var person = _personService.CreatePerson(newPerson);
        //    return Ok(person);
        //}

        //// GET: api/<PersonController>
        //[HttpGet("One/{Id}")]
        //public ActionResult<ResponsePersonDTO> GetPerson(int Id)
        //{
        //    var person = _personService.GetPerson(Id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }
        //    var personDTO = _mapper.Map<ResponsePersonDTO>(person);
        //    return Ok(personDTO);
        //}

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

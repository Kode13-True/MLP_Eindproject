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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // POST api/<StudentController>
        [HttpPost("Create")]
        public ActionResult<Student> CreateNewStudent(CreateStudentDTO createStudentDTO)
        {
            var newStudent = _mapper.Map<Student>(createStudentDTO);
            var student = _studentService.CreateStudent(newStudent);
            return Ok(student);
        }

        // GET: api/<StudentController>
        [HttpGet("One/{Id}")]
        public ActionResult<ResponseStudentDTO> GetStudent(int Id)
        {
            var student = _studentService.GetStudent(Id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = _mapper.Map<ResponseStudentDTO>(student);
            return Ok(studentDTO);
        }

        // GET: api/<StudentController>
        [HttpGet("GetAll")]
        public ActionResult<List<ResponseStudentDTO>> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            var returnList = _mapper.Map<List<ResponseStudentDTO>>(students);
            return Ok(returnList);
        }

        // PUT api/<StudentController>/5
        [HttpPut("Update/{id}")]
        public ActionResult<ResponseStudentDTO> Update(int id, [FromBody] CreateStudentDTO createStudentDTO)
        {
            var student = _mapper.Map<Student>(createStudentDTO);
            var studentResponse = _studentService.UpdateStudentById(id, student);
            var responseStudentDTO = _mapper.Map<ResponseStudentDTO>(studentResponse);
            return Ok(responseStudentDTO);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteStudentById(int id)
        {
            _studentService.DeleteStudentById(id);
            return Ok();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.DTO.PersonDTO;
using MLP_DbLibrary.DTO.RatingDTO;
using MLP_DbLibrary.DTO.UserDTO;
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
        public async Task<ActionResult<ResponseStudentDTO>> CreateNewStudent(CreateStudentDTO createStudentDTO)
        {
            if (createStudentDTO is null)
            {
                return BadRequest();
            }

            var newStudent = _mapper.Map<Student>(createStudentDTO);
            var student = await _studentService.CreateStudent(newStudent);
            var studentDTO = _mapper.Map<ResponseStudentDTO>(student);
            return Ok(studentDTO);
        }

        // GET: api/<StudentController>
        [HttpGet("One/{Id}")]
        public  ActionResult<ResponseStudentDTO> GetStudent(int Id)
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
        public async Task<ActionResult<ResponseStudentDTO>> Update(int id, [FromBody] EditStudentDTO editStudentDTO)
        {
            if (editStudentDTO is null)
            {
                return BadRequest();
            }

            var student = _mapper.Map<Student>(editStudentDTO);
            var studentResponse = await _studentService.UpdateStudentById(id, student);
            var responseStudentDTO = _mapper.Map<ResponseStudentDTO>(studentResponse);
            return Ok(responseStudentDTO);
        }
        [HttpPut("UpdatePassword/{id}")]
        public async Task<ActionResult> UpdatePassword(int id, [FromBody] EditPasswordDTO editPasswordDTO)
        {
            if (editPasswordDTO is null)
            {
                return BadRequest();
            }

            var studentResponse = await _studentService.UpdatePassword(id, editPasswordDTO);
            if (studentResponse == false) { return BadRequest(); }
            return Ok();
        }

        [HttpPut("RateTeacher")]
        public async Task<ActionResult<ResponseLessonDTO>> RateTeacher([FromBody] GiveRatingDTO giveRatingDTO)
        {
            if (giveRatingDTO is null)
            {
                return BadRequest();
            }

            var completedLesson = await _studentService.GiveRating(giveRatingDTO);
            if(completedLesson is null) { return BadRequest(); }
            var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(completedLesson);
            return responseLessonDTO;
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("Delete/{id}")]
        public async Task <ActionResult> DeleteStudentById(int id)
        {
            await _studentService.DeleteStudentById(id);
            return Ok();
        }
    }
}

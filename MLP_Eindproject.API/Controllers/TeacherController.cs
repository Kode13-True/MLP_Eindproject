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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        // POST api/<TeacherController>
        [HttpPost("Create")]
        public ActionResult<Teacher> CreateNewTeacher(CreateTeacherDTO createTeacherDTO)
        {
            var newTeacher = _mapper.Map<Teacher>(createTeacherDTO);
            var teacher = _teacherService.CreateTeacher(newTeacher);
            return Ok(teacher);
        }

        // GET: api/<TeacherController>
        [HttpGet("One/{Id}")]
        public ActionResult<ResponseTeacherDTO> GetTeacher(int Id)
        {
            var teacher = _teacherService.GetTeacher(Id);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherDTO = _mapper.Map<ResponseTeacherDTO>(teacher);
            return Ok(teacherDTO);
        }

        // GET: api/<TeacherController>
        [HttpGet("GetAll")]
        public ActionResult<List<ResponseTeacherDTO>> GetAllTeachers()
        {
            var teachers = _teacherService.GetAllTeachers();
            var returnList = _mapper.Map<List<ResponseTeacherDTO>>(teachers);
            return Ok(returnList);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("Update/{id}")]
        public ActionResult<ResponseTeacherDTO> Update(int id, [FromBody] CreateTeacherDTO createTeacherDTO)
        {
            var teacher = _mapper.Map<Teacher>(createTeacherDTO);
            var teacherResponse = _teacherService.UpdateTeacherById(id, teacher);
            var responseTeacherDTO = _mapper.Map<ResponseTeacherDTO>(teacherResponse);
            return Ok(responseTeacherDTO);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteTeacherById(int id)
        {
            _teacherService.DeleteTeacherById(id);
            return Ok();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO.LessonDTO;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLP_Eindproject.API.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        public LessonController(ILessonService lessonService, IMapper mapper) 
        {
            _mapper = mapper;
            _lessonService = lessonService;
        }
        // GET: api/<LessonController>
        [HttpGet("GetAllUnbooked")]
        public ActionResult<List<ResponseLessonDTO>> GetAll()
        {
            var unbookedLessonsDTO = new List<ResponseLessonDTO>();
            var unbookedLessons = _lessonService.GetAllUnbookedLessons();
            foreach(var l in unbookedLessons)
            {
                var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(l);
                unbookedLessonsDTO.Add(responseLessonDTO);
            }
            return Ok(unbookedLessonsDTO);
        }// GET: api/<LessonController>
        [HttpGet("GetAllTeacherLessons/{teacherId}")]
        public ActionResult<List<ResponseLessonDTO>> GetAllTeacherLessons(int teacherId)
        {
            var responseLessonsDTO = new List<ResponseLessonDTO>();
            var lessons = _lessonService.GetAllTeacherLessons(teacherId);
            foreach(var l in lessons)
            {
                var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(l);            
                responseLessonsDTO.Add(responseLessonDTO);
            }
            return Ok(responseLessonsDTO);
        }// GET: api/<LessonController>
        [HttpGet("GetAllStudentLessons/{studentId}")]
        public ActionResult<List<ResponseLessonDTO>> GetAllStudentLessons(int studentId)
        {
            var responseLessonsDTO = new List<ResponseLessonDTO>();
            var lessons = _lessonService.GetAllStudentLessons(studentId);
            foreach(var l in lessons)
            {
                var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(l);
                responseLessonsDTO.Add(responseLessonDTO);
                
            }
            return Ok(responseLessonsDTO);
        }

        // GET api/<LessonController>/5
        [HttpGet("GetOne/{id}")]
        public async Task<ActionResult<ResponseLessonDTO>> GetOne(int id)
        {
            var lesson = await _lessonService.GetOneLessonById(id);
            var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(lesson);
            return Ok(responseLessonDTO);
        }

        // POST api/<LessonController>
        [HttpPost("CreateLesson/{teacherId}")]
        public async Task<ActionResult<ResponseLessonDTO>> Post(int teacherId, [FromBody] CreateLessonDTO createLessonDTO)
        {
            if (createLessonDTO is null)
            {
                throw new ArgumentNullException(nameof(createLessonDTO));
            }

            var lessonToCreate = _mapper.Map<Lesson>(createLessonDTO);
            var responseLesson =await _lessonService.CreateLessonByTeacherId(teacherId, lessonToCreate);
            var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(responseLesson);
            return Ok(responseLessonDTO);
        }

        // PUT api/<LessonController>/5
        [HttpPut("UpdateLesson/{lessonId}")]
        public async Task<ActionResult<ResponseLessonDTO>> Put(int lessonId, [FromBody] EditLessonDTO editLessonDTO)
        {
            if (editLessonDTO is null)
            {
                throw new ArgumentNullException(nameof(editLessonDTO));
            }

            var responseLesson = await _lessonService.UpdateLessonByTeacherId(lessonId, editLessonDTO);
            var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(responseLesson);
            return Ok(responseLessonDTO);

        }
        // PUT api/<LessonController>/5
        [HttpGet("BookLesson/{studentId}/{lessonId}")]
        public async Task<ActionResult<ResponseLessonDTO>> BookLesson(int studentId, int lessonId)
        {
            var responseLesson = await _lessonService.BookLesson(studentId, lessonId);
            if(responseLesson is null) { return BadRequest(); }
            var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(responseLesson);
            return Ok(responseLessonDTO);
        }
        // PUT api/<LessonController>/5
        [HttpGet("CancelLesson/{lessonId}")]
        public async Task<ActionResult<ResponseLessonDTO>> CancelLesson(int lessonId)
        {
            var responseLesson = await _lessonService.CancelLesson(lessonId);
            var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(responseLesson);
            return Ok(responseLessonDTO);
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("DeleteLesson/{id}")]
        public async Task<ActionResult<ResponseLessonDTO>> Delete(int id)
        {
            var responseLesson = await _lessonService.DeleteLesson(id);
            var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(responseLesson);
            return Ok(responseLessonDTO);
        }
    }
}

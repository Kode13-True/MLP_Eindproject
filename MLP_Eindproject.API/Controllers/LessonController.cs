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
        public readonly ILessonService _lessonService;
        public readonly IMapper _mapper;
        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }
        // GET: api/<LessonController>
        [HttpGet("GetAll")]
        public List<Lesson> Get()
        {
            return _lessonService.GetAllLessons();
            
        }

        // GET api/<LessonController>/5
        [HttpGet("Details/{id}")]
        public async Task<Lesson> Get(int id)
        {
            return await _lessonService.GetDetailsById(id);
        }

        // POST api/<LessonController>
        [HttpPost("CreateLesson/{teacherId}")]
        public async void Post(int teacherId,[FromBody] CreateLessonDTO createLessonDTO)
        {
           
            if (createLessonDTO is null)
            {
                throw new ArgumentNullException(nameof(createLessonDTO));
            }
            var lesson = _mapper.Map<Lesson>(createLessonDTO);
            var lessonFromDb = await _lessonService.CreateLesson(lesson);
            await _lessonService.AddTeacherToLesson(teacherId, lessonFromDb);
        }


        // PUT api/<LessonController>/5
        [HttpPut("EditForTeacher/{id}")]
        public async void EditLesson(int id, [FromBody] EditLessonDTO editLessonDTO)
        {
            if (editLessonDTO is null)
            {
                throw new ArgumentNullException(nameof(editLessonDTO));
            }

            var lesson = _mapper.Map<Lesson>(editLessonDTO);
            await _lessonService.EditLesson(id, lesson);
        }

        [HttpPut("BookLesson/{studentId}/{lessonId}")]
        public async void BookLesson(int studentId, int lessonId)
        {
            await _lessonService.BookLesson(studentId, lessonId);
        }

        // DELETE api/<LessonController>/5
        [HttpDelete("Delete/{id}")]
        public async void Delete(int id)
        {
            await _lessonService.DeleteLessonById(id);
        }
    }
}

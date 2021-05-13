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
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(ISearchService searchService, IMapper mapper)
        {
            _mapper = mapper;
            _searchService = searchService;
        }
        // GET: api/<SearchController> 
        [HttpGet ("SearchLessons")]
        public ActionResult<List<ResponseLessonDTO>> SearchLessons (InstrumentName? instrumentName, InstrumentStyle? instrumentStyle, decimal? price, string postal, string teacherName)
        {
            var searchLessonsDTO = new List<ResponseLessonDTO>();
            var searchedLessons = _searchService.SearchLessons(instrumentName,instrumentStyle,price,postal,teacherName);
            foreach (var l in searchedLessons)
            {
                var responseLessonDTO = _mapper.Map<ResponseLessonDTO>(l);
                searchLessonsDTO.Add(responseLessonDTO);
            }
            return Ok(searchLessonsDTO);
        }

       
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO.LocationDTO;
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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public LocationController(IMapper mapper, ILocationService locationService)
        {
            _locationService = locationService;
            _mapper = mapper;
        }
        // GET: api/<LocationController>
        [HttpGet("GetMany")]
        public ActionResult<List<ResponseLocationDTO>> Get()
        {
            var responseLocations = new List<ResponseLocationDTO>();
            var locations = _locationService.GetAllLocations();
            foreach(var l in locations)
            {
                var rl = _mapper.Map<ResponseLocationDTO>(l);
                responseLocations.Add(rl);
            }
            return Ok(responseLocations);
        }

        // GET api/<LocationController>/5
        [HttpGet("GetOne/{id}")]
        public ActionResult<ResponseLocationDTO> Get(int id)
        {
            var location = _locationService.GetLocationById(id);
            if(location is null)
            {
                return NotFound();
            }
            var responseLocation = _mapper.Map<ResponseLocationDTO>(location);
            return Ok(responseLocation);

        }

        // POST api/<LocationController>
        [HttpPost("Create")]
        public ActionResult<ResponseLocationDTO> Post([FromBody] CreateLocationDTO createLocationDTO)
        {
            if (createLocationDTO is null)
            {
                throw new ArgumentNullException(nameof(createLocationDTO));
            }
            var location = _mapper.Map<Location>(createLocationDTO);
            var locationResponse = _locationService.CreateLocation(location);
            return Ok(locationResponse);
        }

        // PUT api/<LocationController>/5
        [HttpPut("Update/{id}")]
        public ActionResult<ResponseLocationDTO> Update(int id, [FromBody] CreateLocationDTO createLocationDTO)
        {
            var location = _mapper.Map<Location>(createLocationDTO);
            var locationResponse = _locationService.UpdateLocation(id, location);
            var responseLocationDTO = _mapper.Map<ResponseLocationDTO>(locationResponse);
            return Ok(responseLocationDTO);
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            _locationService.DeleteLocationById(id);
            return Ok();
        }
    }
}

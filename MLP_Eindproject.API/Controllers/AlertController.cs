using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO.AlertDTO;
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
    public class AlertController : ControllerBase
    {
        private readonly IAlertService _alertService;
        private readonly IMapper _mapper;

        public AlertController(IAlertService alertService, IMapper mapper)
        {
            _alertService = alertService;
            _mapper = mapper;
        }

        // POST api/<AlertController>
        [HttpPost("Create/{personId}")]
        public async Task<ActionResult<CreateAlertDTO>> CreateNewAlert(int personId, [FromBody] CreateAlertDTO createAlertDTO)
        {
            var newAlert = _mapper.Map<Alert>(createAlertDTO);
            var alert = await _alertService.CreateAlert(newAlert, personId);
            var alertDTO = _mapper.Map<ResponseAlertDTO>(alert);
            return Ok(alertDTO);
        }

        // GET: api/<AlertController>/5
        [HttpGet("One/{Id}")]
        public async Task<ActionResult<ResponseAlertDTO>> GetAlert(int Id)
        {
            var alert = await _alertService.GetAlert(Id);
            if (alert == null)
            {
                return NotFound();
            }
            var alertDTO = _mapper.Map<ResponseAlertDTO>(alert);
            return Ok(alertDTO);
        }

        // GET api/<AlertController>
        [HttpGet("GetAll")]
        public ActionResult<List<ResponseAlertDTO>> GetAllAlerts()
        {
            var alerts = _alertService.GetAllAlerts();
            var returnList = _mapper.Map<List<ResponseAlertDTO>>(alerts);
            return Ok(returnList);
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAlertById(int id)
        {
            await _alertService.DeleteAlertById(id);
            return Ok();
        }
    }
}

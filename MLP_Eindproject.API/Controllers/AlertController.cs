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
        [HttpPost("Create")]
        public async Task<ActionResult<CreateAlertDTO>> CreateNewAlert([FromBody] CreateAlertDTO createAlertDTO)
        {
            if (createAlertDTO is null)
            {
                return BadRequest();
            }

            var newAlert = _mapper.Map<Alert>(createAlertDTO);
            var alert = await _alertService.CreateAlert(newAlert);
            if(alert == null) { return BadRequest(); }
            var alertDTO = _mapper.Map<ResponseAlertDTO>(alert);
            return Ok(alertDTO);
        }

        [HttpPost("Report")]
        public async Task<ActionResult<CreateReportDTO>> ReportUserToAdmin([FromBody] CreateReportDTO createReportDTO)
        {
            if (createReportDTO is null)
            {
                return BadRequest();
            }

            var newAlert = new Alert() { AlertType = AlertType.Report, Message = createReportDTO.Message };
            var alert = await _alertService.ReportUser(newAlert);
            if(alert == null) { return BadRequest(); }
            var alertDTO = _mapper.Map<ResponseAlertDTO>(alert);
            return Ok(alertDTO);
        }

        // GET: api/<AlertController>/5
        [HttpGet("One/{Id}")]
        public ActionResult<ResponseAlertDTO> GetAlert(int Id)
        {
            var alert = _alertService.GetAlert(Id);
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
        [HttpGet("GetAllByPersonId/{id}")]
        public ActionResult<List<ResponseAlertDTO>> GetAlertsByPersonId(int id)
        {
            var alerts = _alertService.GetAlertsByPersonId(id);
            var returnList = _mapper.Map<List<ResponseAlertDTO>>(alerts);
            return Ok(returnList);
        }
        [HttpGet("GetReportsByAdmin")]
        public ActionResult<List<ResponseAlertDTO>> GetAlertsByAdmin()
        {
            var alerts = _alertService.GetAlertsByAdmin();
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
        [HttpDelete("DeleteAll/{id}")]
        public async Task<ActionResult> DeleteAllAlerts(int id)
        {
            await _alertService.DeleteAllALertsById(id);
            return Ok();
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO;
using MLP_DbLibrary.DTO.InstrumentDTO;
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
    public class InstrumentController : ControllerBase
    {

        private readonly IInstrumentService _instrumentService;
        private readonly IMapper _mapper;

        public InstrumentController(IInstrumentService instrumentService, IMapper mapper)
        {
            _instrumentService = instrumentService;
            _mapper = mapper;
        }

        // POST api/<InstrumentController>
        [HttpPost("Create")]
        public ActionResult<Instrument> CreateNewInstrument(CreateInstrumentDTO createInstrumentDTO)
        {
            Instrument newInstrument = _mapper.Map<Instrument>(createInstrumentDTO);
            var instrument = _instrumentService.CreateInstrument(newInstrument);
            return Ok(instrument);
        }

        // GET api/<InstrumentController>/5
        [HttpGet("One/{Id}")]
        public ActionResult<ResponseInstrumentDTO> GetInstrument(int Id)
        {
            var instrument = _instrumentService.GetInstrument(Id);
            if (instrument == null)
            {
                return NotFound();
            }
            var instrumentDTO = _mapper.Map<ResponseInstrumentDTO>(instrument);
            return Ok(instrumentDTO);
        }

        // GET: api/<InstrumentController>
        [HttpGet("GetAll")]
        public ActionResult<List<ResponseInstrumentDTO>> GetAllInstruments()
        {
            var instruments = _instrumentService.GetAllInstruments();
            var returnList = _mapper.Map<List<ResponseInstrumentDTO>>(instruments);
            return Ok(returnList);            
        }

        // DELETE api/<InstrumentController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteInstrumentById(int id)
        {
            _instrumentService.DeleteInstrumentById(id);
            return Ok();
        }
    }
}

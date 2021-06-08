using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO.PersonDTO;
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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

            public AdminController(IAdminService adminService, IMapper mapper)
            {
                _adminService = adminService;
                _mapper = mapper;
            }

        // POST api/<AdminController>
        [HttpPost("Create")]
            public async Task<ActionResult<Admin>> CreateAdmin(CreateAdminDTO createAdminDTO)
            {
                var newAdmin = _mapper.Map<Admin>(createAdminDTO);
                var admin = await _adminService.CreateAdmin(newAdmin);
                return Ok(admin);
            }

        // GET: api/<AdminController>
        [HttpGet("One/{Id}")]
            public ActionResult<ResponseAdminDTO> GetAdmin(int Id)
            {
                var admin = _adminService.GetAdmin(Id);
                if (admin == null)
                {
                    return NotFound();
                }
                var adminDTO = _mapper.Map<ResponseAdminDTO>(admin);
                return Ok(adminDTO);
            }

        // GET: api/<AdminController>
        [HttpGet("GetAll")]
            public ActionResult<List<ResponseAdminDTO>> GetAllAdmins()
            {
                var admins = _adminService.GetAllAdmins();
                var returnList = _mapper.Map<List<ResponseAdminDTO>>(admins);
                return Ok(returnList);
            }

        // GET: api/<AdminController>
        [HttpGet("GetUserNumbers")]
        public ActionResult<int[]> GetUserNumbers()
        {
            var response = _adminService.GetNumberOfUsers();
            return Ok(response);
        }
        // GET: api/<AdminController>
        [HttpGet("GetLessonNumbers")]
        public ActionResult<int[]> GetLessonNumbers()
        {
            var response = _adminService.GetNumberOfLessons();
            return Ok(response);
        }
        // GET: api/<AdminController>
        [HttpGet("GetLevelNumbers")]
        public ActionResult<int[]> GetLevelNumbers()
        {
            var response = _adminService.GetNumberOfLevels();
            return Ok(response);
        }
        // GET: api/<AdminController>
        [HttpGet("GetStyleNumbers")]
        public ActionResult<int[]> GetStyleNumbers()
        {
            var response = _adminService.GetNumberOfStyles();
            return Ok(response);
        }
        // GET: api/<AdminController>
        [HttpGet("GetInstrumentNumbers")]
        public ActionResult<int[]> GetInstrumentNumbers()
        {
            var response = _adminService.GetNumberOfInstruments();
            return Ok(response);
        }


        // PUT api/<AdminController>/5
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<ResponseAdminDTO>> Update(int id, [FromBody] EditAdminDTO editAdminDTO)
        {
            var admin = _mapper.Map<Admin>(editAdminDTO);
            var adminResponse = await _adminService.UpdateAdminById(id, admin);
            var responseAdminDTO = _mapper.Map<ResponseAdminDTO>(adminResponse);
            return Ok(responseAdminDTO);
        }
        [HttpPut("UpdatePassword/{id}")]
        public async Task<ActionResult> UpdatePassword(int id, [FromBody] EditPasswordDTO editPasswordDTO)
        {
            var adminResponse = await _adminService.UpdatePassword(id, editPasswordDTO);
            if(adminResponse == false) { return BadRequest(); }
            return Ok();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAdminById(int id)
        {
            await _adminService.DeleteAdminById(id);
            return Ok();
        }

        [HttpPut("DeleteUser")]
        public async Task<ActionResult> DeletUserByAdmin(DeleteUserDTO deleteUserDTO)
        {
            bool deleteSucceed = await _adminService.DeleteUserByAdmin(deleteUserDTO);
            if(deleteSucceed is false) { return BadRequest(); }
            return Ok();
        }
    }
    
}

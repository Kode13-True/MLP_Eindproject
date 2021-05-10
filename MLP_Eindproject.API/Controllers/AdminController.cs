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
            public ActionResult<Admin> CreateNewAdmin(CreateAdminDTO createAdminDTO)
            {
                var newAdmin = _mapper.Map<Admin>(createAdminDTO);
                var admin = _adminService.CreateAdmin(newAdmin);
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
                var adminDTO = _mapper.Map<ResponseStudentDTO>(admin);
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
        [HttpGet("GetNumberOfUsers")]
        public ActionResult<int> GetAllUsers()
        {
            var users = _adminService.GetNumberOfUsers();
            return Ok(users);
        }

        // PUT api/<AdminController>/5
        [HttpPut("Update/{id}")]
            public ActionResult<ResponseAdminDTO> Update(int id, [FromBody] CreateAdminDTO createAdminDTO)
            {
                var admin = _mapper.Map<Admin>(createAdminDTO);
                var adminResponse = _adminService.UpdateAdminById(id, admin);
                var responseAdminDTO = _mapper.Map<ResponseAdminDTO>(adminResponse);
                return Ok(responseAdminDTO);
            }

        // DELETE api/<AdminController>/5
        [HttpDelete("Delete/{id}")]
            public ActionResult DeleteAdminById(int id)
            {
                _adminService.DeleteAdminById(id);
                return Ok();
            }
    }
    
}

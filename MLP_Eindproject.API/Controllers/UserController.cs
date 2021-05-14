using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO.UserDTO;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLP_Eindproject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        //[HttpPost("Authenticate")]
        //public async Task<ActionResult> Authenticate(string token)
        //{

        //}
        //[HttpPost("LogIn")]
        //public async Task<ActionResult> LogIn(string email, string password)
        //{

        //}
        //[HttpPost("Register")]
        //public async Task<ActionResult> Register(RegisterUserDTO registerUserDTO)
        //{

        //}
        //[HttpPost("LogOut")]
        //public async Task<ActionResult> LogOut(string Token)
        //{

        //}
    }
}

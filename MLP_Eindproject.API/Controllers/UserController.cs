using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MLP_DbLibrary.DTO.UserDTO;
using MLP_DbLibrary.Models;
using MLP_Eindproject.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        [HttpPost("Authenticate")]
        public ActionResult<int> Authenticate(string token)
        {
            
            var activeUser = _userService.UserExistanceByToken(token);
            if(activeUser is false) { return BadRequest("Not an active user"); }
            var decryptedToken = _userService.DecryptTokenForAuthentication(token);
            if(decryptedToken is null) { return BadRequest("token not found"); }
            var splitToken = decryptedToken.Split(";");
            var id = int.Parse(splitToken[0]);
            var pattern = "yyyy/MM/dd-HH:mm:ss:ffff";
            DateTime.TryParseExact(splitToken[1], pattern, null, DateTimeStyles.None, out DateTime timeOfLogIn);
            if (timeOfLogIn.AddMinutes(60) < DateTime.Now)
            {
                return BadRequest("Your session has been ended, please log in again");
            }

            return Ok(id);
        }
        [HttpPost("LogIn")]
        public async Task<ActionResult<string>> LogIn(LoginUserDTO loginUserDTO)
        {
            var encryptedEmail = _userService.HashForRegistrationAndLogin(loginUserDTO.Email); ;
            var encryptedPassword = _userService.HashForRegistrationAndLogin(loginUserDTO.Password);
            var user = _userService.GetUserFromDb(encryptedEmail, encryptedPassword);
            if(user is null) { return BadRequest("user does not exist"); }
            var token = _userService.EncryptTokenForAuthentication(user);
            await _userService.AddTokenToUser(user ,token);          

            return Ok(token);
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterUserDTO registerUserDTO)
        {            
            if (registerUserDTO is null)
            {
                throw new ArgumentNullException(nameof(registerUserDTO));
            }
            registerUserDTO.Email = _userService.HashForRegistrationAndLogin(registerUserDTO.Email);
            registerUserDTO.Password = _userService.HashForRegistrationAndLogin(registerUserDTO.Password);
            if (registerUserDTO.IsAdmin is true)
            {
                await _userService.AddAdminToDb(_mapper.Map<Admin>(registerUserDTO));
            }
            else 
            {
                if (registerUserDTO.IsTeacher is true)
                {
                    await _userService.AddTeacherToDb(_mapper.Map<Teacher>(registerUserDTO));
                }
                else
                {
                    await _userService.AddStudentToDb(_mapper.Map<Student>(registerUserDTO));
                }
            }
            if(registerUserDTO.IsAdmin == false & registerUserDTO.IsTeacher == false) { return BadRequest(); }
            
            return Ok();
        }
        [HttpPost("LogOut")]
        public async Task<ActionResult> LogOut(string token)
        {
            await _userService.LogUserOut(token);
            return Ok("user is logged out");
        }
    }
}

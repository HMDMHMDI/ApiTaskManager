using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTaskManager.Dto;
using ApiTaskManager.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AccountController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok("Successful");
        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUser(int userId)
        {
            if (_userRepository.UserExist(userId))
            {
                return NotFound();
            }

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userId));
            if (!ModelState.IsValid)
            {
                return BadRequest(user);
            }

            return Ok("Success");
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser( UserDto userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest(ModelState);
            }
            // Check User Exist :
            var users = _userRepository.GetUsers()
                .Where(e => e.EmailAddress.Trim().ToUpper() == userCreate.EmailAddress.TrimEnd().ToUpper()).FirstOrDefault();
            if (users != null)
            {
                ModelState.AddModelError("" , "User already Exist !");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userMap = _mapper.Map<User>(userCreate);
            if (_userRepository.Add(userMap)) return Ok("Successful");
            ModelState.AddModelError("Failed" , "Something went wrong !");
            return StatusCode(500, ModelState);

        }
    }
}

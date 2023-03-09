using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using new_project.Models;
using new_project.Dtos;
using new_project.Services;

namespace new_project.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUser(int id)
        {
            return Ok(await _userService.GetUser(id));
        }

        [HttpPost("")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> AddUser(AddUserDto newUser)
        {
            return Ok(await _userService.AddUser(newUser));
        }

        [HttpPut("")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUser(UpdateUserDto updatedUser)
        {
            var response = await _userService.UpdateUser(updatedUser);
            
            if (response.data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> DeleteUser(int id)
        {
            var response = await _userService.DeteteUser(id);

            if (response.data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
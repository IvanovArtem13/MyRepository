﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineCard.DTO;
using MedicineCard.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicineCard.Controllers
{
    [Route("users")] 
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(long id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost("auth")]
        public IActionResult Auth(AuthRequest request)
        {
            var result = _userService.Auth(request);
            if (result == null)
            {
                return BadRequest("Error");
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            var result = await _userService.Add(userDto);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult UpdateProfile(UserDto userDto)
        {
            var result = _userService.Update(userDto);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteUser(long id)
        {
            _userService.Delete(id);
            return Ok("User deleted!");
        }


    }
}

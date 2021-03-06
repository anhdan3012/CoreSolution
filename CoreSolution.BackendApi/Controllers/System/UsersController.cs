﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSolution.Application.System.Users;
using CoreSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreSolution.BackendApi.Controllers.System
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _userService.Authencate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("Username or password is incorrect.");
            }
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessful.");
            }
            return Ok();
        }
         
        [HttpGet("paging")] 
        public async Task<IActionResult> GetAllPaging([FromQuery]UserGetAllPagingRequest request)
        {
            var result = await _userService.GetAllPaging(request);
            return Ok(result);
        }
    }
}
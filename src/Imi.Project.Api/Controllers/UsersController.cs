using Imi.Project.Api.Core.Dtos.User;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto registerRequestDto)
        {
            try
            {
                var result = await _userService.RegisterAsync(registerRequestDto);

                if(result.Succeeded)
                    return Ok("Thank you for your registration, you can now login");
                else
                    return BadRequest(result.ErrorMessages);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
                return BadRequest(ModelState);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto requestDto)
        {
            try
            {
                var result = await _userService.LoginAsync(requestDto);

                if (result.Succeeded)
                {
                    var responseDto = new LoginResponseDto { JwtToken = result.JwtToken };
                    return Ok(responseDto);
                }
                else
                {
                    return Unauthorized(result.ErrorMessages);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Source, ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "SuperAdmin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            if (result.Succeeded)
            {
                return BadRequest(result.ErrorMessages);
            }
            return Ok("User was deleted successfully");
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGDictionary.Database.Entity;
using NGDictionary.Dto;
using NGDictionary.Services.Interfaces;

namespace NGDictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register(RegisterCredentialsDto credintials)
        {
            if (credintials is null)
            {
                return BadRequest("Invalid credentials.");
            }

            // await _authService.AddUserAsync(user);
            return Ok();
        }
        
        [HttpPost("login")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginCredentionalsDto? credentials)
        {
            if (credentials is null 
                || credentials.Username is null
                || credentials.Password is null)
            {
                return BadRequest("Invalid credentials.");
            }

            try
            {
                var user = await _authService.LoginAsync(credentials.Username, credentials.Password);
                return Ok(user);
            }
            catch (AuthenticationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _authService.Dispose();
            base.Dispose(disposing);
        }
    }
}
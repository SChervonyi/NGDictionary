using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _authService.AddUserAsync(user);
            return Ok(user);
        }        
        
        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            try
            {
                await _authService.LoginAsync(user.Username, user.Password);
            }
            catch (AuthenticationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500);
            }
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            _authService.Dispose();
            base.Dispose(disposing);
        }
    }
}
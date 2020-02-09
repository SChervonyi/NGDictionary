using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _authService.AddUserAsync(user);
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            _authService.Dispose();
            base.Dispose(disposing);
        }
    }
}
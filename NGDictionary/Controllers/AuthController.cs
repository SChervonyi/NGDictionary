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
        private IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            authService.AddUser(user);
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            authService.Dispose();
            base.Dispose(disposing);
        }
    }
}
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Models.Dto;
using AareonTechnicalTest.Services.Abstract;
using AareonTechnicalTest.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IPersonService _personServie;
        public AuthController(IPersonService personServie)
        {
            _personServie = personServie;
        }

        [HttpPost("Signin")]
        public IActionResult Signin(LoginDto loginDto)
        {
            var user = _personServie.GetUserForLogin(loginDto.Username, loginDto.Password);
            if (!user.IsSucceeded) return BadRequest(user.ExceptionMessages);

            Response.Cookies.Append("signedUser", JsonConvert.SerializeObject(user, Formatting.Indented), 
                                    new CookieOptions { Expires = DateTimeOffset.Now.AddHours(24) });
            string result = $"{user.Data.Username} is Signed in!";
            return Ok(result);
        }


        [HttpPost("Register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var registeredUserResult = _personServie.RegisterUser(registerDto.MapToPerson());

            if (!registeredUserResult.IsSucceeded) return BadRequest(registeredUserResult.ExceptionMessages);

            Response.Cookies.Append("signedUser", JsonConvert.SerializeObject(registeredUserResult, Formatting.Indented),
                                    new CookieOptions { Expires = DateTimeOffset.Now.AddHours(24) });
            string result = $"{registeredUserResult.Data.Username} is Registered in and stored!";
            return Ok(result);
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("signedUser");
            string result = "User Logged Out!";
            return Ok(result);
        }
    }
}

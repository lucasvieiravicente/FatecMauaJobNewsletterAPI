using System;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FatecMauaJobNewsletter.Controllers.SharedControllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        public LoginController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<LoginResponse> Login(LoginRequest loginRequest)
        {
            try 
            {                
                return Ok(_userLoginService.LoginRequest(loginRequest));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

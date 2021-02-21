using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FatecMauaJobNewsletter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        public LoginController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            var result = _userLoginService.LoginRequest(request);

            if (!(result is null))
                return Ok(result);
            else
                return NotFound("Nenhum registro encontrado, verifique seu login e senha");
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public ActionResult SignUp(SignUpRequest request)
        {
            try
            {
                return Ok(_userLoginService.RegisterUser(request));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("SignUpAdministration")]
        [Authorize(UserClaim.Administration)]
        public ActionResult SignUpAdministration(SignUpRequest request)
        {
            try
            {
                return Ok(_userLoginService.RegisterAdministrationUser(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Date")] 
        [Authorize(UserClaim.Student)]
        public ActionResult<DateTime> GetDate()
        {
            return Ok(DateTime.Now);
        }
    }
}

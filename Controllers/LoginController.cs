using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<ActionResult> SignUp(SignUpRequest request)
        {
            try
            {
                await _userLoginService.RegisterUser(request);
                return Ok(request);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("SignUpAdministration")]
        [Authorize(UserClaim.Administration)]
        public async Task<ActionResult> SignUpAdministration(SignUpRequest request)
        {
            try
            {
                await _userLoginService.RegisterAdministrationUser(request);
                return Ok(request);
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

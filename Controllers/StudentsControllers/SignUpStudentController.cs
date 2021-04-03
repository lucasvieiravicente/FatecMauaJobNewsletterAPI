using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Controllers.StudentsControllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignUpStudentController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        public SignUpStudentController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(SignUpRequest request)
        {
            try
            {
                await _userLoginService.RegisterUser(request);
                return Ok("Registro concluído com sucesso");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

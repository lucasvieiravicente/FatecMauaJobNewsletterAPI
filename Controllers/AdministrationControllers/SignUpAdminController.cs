using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Controllers.AdministrationControllers
{
    [Route("[controller]")]
    [ApiController]
    public class SignUpAdminController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        public SignUpAdminController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpPost]
        [Authorize(UserClaim.Administration)]
        public async Task<ActionResult> SignUp(SignUpRequest request)
        {
            try
            {
                await _userLoginService.RegisterAdministrationUser(request);
                return Ok("Registro concluído com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

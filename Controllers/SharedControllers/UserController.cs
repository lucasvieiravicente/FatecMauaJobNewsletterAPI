using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Domains.Models.Request;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Controllers.SharedControllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;

        public UserController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpGet("GetUser")]
        [Authorize(UserClaim.AtLeastAuthenticated)]
        public ActionResult<UserUpdate> GetUser()
        {
            try
            {
                return Ok(_userLoginService.GetUserByLogin());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("UpdateUser")]
        [Authorize(UserClaim.AtLeastAuthenticated)]
        public async Task<ActionResult<UserUpdate>> UpdateUser(UserUpdate request)
        {
            try
            {
                await _userLoginService.UpdateUser(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

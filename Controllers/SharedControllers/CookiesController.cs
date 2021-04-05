using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Domains.Models.Request;
using FatecMauaJobNewsletter.Models.Pages;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FatecMauaJobNewsletter.Controllers.SharedControllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class CookiesController : ControllerBase
    {
        private readonly ICookiesService _cookiesService;

        public CookiesController(ICookiesService cookiesService)
        {
            _cookiesService = cookiesService;
        }

        [HttpGet("VerifyToken")]
        public ActionResult<UserLogged> VerifyToken()
        {
            try
            {
                UserLogged userLogged = new UserLogged
                {
                    IsLogged = _cookiesService.IsLogged(),
                    IsAdmin = _cookiesService.IsAdmin()
                };

                return Ok(userLogged);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

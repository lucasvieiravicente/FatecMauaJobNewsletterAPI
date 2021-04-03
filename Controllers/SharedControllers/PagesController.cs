using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Models.Pages;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Controllers.SharedControllers
{
    [Route("[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IPagesService _pagesService;

        public PagesController(IPagesService pagesService)
        {
            _pagesService = pagesService;
        }

        [HttpGet("GetStates")]
        [Authorize(UserClaim.AtLeastAuthenticated)]
        public async Task<ActionResult<State[]>> GetStates()
        {
            try
            {
                return Ok(await _pagesService.GetStates());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetCities/{stateId}")]
        [Authorize(UserClaim.AtLeastAuthenticated)]
        public async Task<ActionResult<City[]>> GetCities(string stateId)
        {
            try
            {
                return Ok(await _pagesService.GetCities(stateId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetNeighborhood/{zipCode}")]
        [Authorize(UserClaim.AtLeastAuthenticated)]
        public async Task<ActionResult<Address>> GetNeighborhood(string zipCode)
        {
            try
            {
                return Ok(await _pagesService.GetNeighborhoodByZipCode(zipCode));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

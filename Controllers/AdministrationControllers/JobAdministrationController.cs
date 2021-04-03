using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Models.Pagination;
using FatecMauaJobNewsletter.Models.Request;
using FatecMauaJobNewsletter.Models.Response;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Controllers.AdministrationControllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobAdministrationController : ControllerBase
    {
        private readonly IJobVacancyService _jobVacancyService;

        public JobAdministrationController(IJobVacancyService jobVacancyService)
        {
            _jobVacancyService = jobVacancyService;
        }

        [HttpPost("PaginatedJobResumes")]
        [Authorize(UserClaim.Administration)]
        public ActionResult<PaginationResponse<JobResume>> GetPaginatedJobs(PaginationRequest request)
        {
            try
            {
                return Ok(_jobVacancyService.GetPaginatedJobResumesPending(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AproveJob")]
        [Authorize(UserClaim.Administration)]
        public async Task<ActionResult> AproveJob(JobManagement request)
        {
            try
            {
                await _jobVacancyService.AproveJob(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ReproveJob")]
        [Authorize(UserClaim.Administration)]
        public async Task<ActionResult> ReproveJob(JobManagement request)
        {
            try
            {
                await _jobVacancyService.ReproveJob(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RemoveJob")]
        [Authorize(UserClaim.Administration)]
        public async Task<ActionResult> RemoveJob(JobManagement request)
        {
            try
            {
                await _jobVacancyService.RemoveJob(request.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using FatecMauaJobNewsletter.Domains.Claims;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Models.Pagination;
using FatecMauaJobNewsletter.Models.Request;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Controllers.SharedControllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobVacancyController : ControllerBase
    {
        private readonly IJobVacancyService _jobVacancyService;

        public JobVacancyController(IJobVacancyService jobVacancyService)
        {
            _jobVacancyService = jobVacancyService;
        }

        [HttpPost("PaginatedAprovedJobResumes")]
        [AllowAnonymous]
        public ActionResult<PaginationResponse<JobVacancy>> GetAprovedPaginatedJobs(PaginationRequest request)
        {
            try
            {
                return Ok(_jobVacancyService.GetPaginatedJobResumesAproved(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PaginatedUserAprovedJobResumes")]
        [Authorize(UserClaim.Student)]
        public ActionResult<PaginationResponse<JobVacancy>> GetUserAprovedPaginatedJobs(PaginationRequest request)
        {
            try
            {
                return Ok(_jobVacancyService.GetPaginatedUserJobResumesAproved(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PaginatedUserReprovedJobResumes")]
        [Authorize(UserClaim.Student)]
        public ActionResult<PaginationResponse<JobVacancy>> GetUserReprovedPaginatedJobs(PaginationRequest request)
        {
            try
            {
                return Ok(_jobVacancyService.GetPaginatedUserJobResumesReproved(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(UserClaim.AtLeastAuthenticated)]
        public async Task<ActionResult> InsertJob(JobVacancyRequest request)
        {
            try
            {
                await _jobVacancyService.InsertJob(request);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{jobId}")]
        [Authorize(UserClaim.Student)]
        public async Task<ActionResult> UpdateJob(JobVacancyRequest request, Guid jobId)
        {
            try
            {
                await _jobVacancyService.UpdateJob(request, jobId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{jobId}")]
        [Authorize(UserClaim.AtLeastAuthenticated)]
        public async Task<ActionResult<JobVacancy>> GetJobById(Guid jobId)
        {
            try
            {
                return Ok(await _jobVacancyService.FindJobById(jobId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

using FatecMauaJobNewsletter.Domains.Enums;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Domains.Utils;
using FatecMauaJobNewsletter.Models.Pagination;
using FatecMauaJobNewsletter.Models.Request;
using FatecMauaJobNewsletter.Models.Response;
using FatecMauaJobNewsletter.Repositories.Interfaces;
using FatecMauaJobNewsletter.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services
{
    public class JobVacancyService : BaseService, IJobVacancyService
    {
        private readonly IJobVacancyRepository _jobVacancyRepository;

        public JobVacancyService(IJobVacancyRepository jobVacancyRepository, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _jobVacancyRepository = jobVacancyRepository;
        }

        public async Task InsertJob(JobVacancyRequest request)
        {
            var job = request.Adapt<JobVacancy>();
            job.UserCreated = GetLogin();
            AuditHelper.UpdateAuditInfo(job, EntityState.Added, GetName());
            await _jobVacancyRepository.InsertAsync(job);
        }

        public async Task UpdateJob(JobVacancyRequest request, Guid jobId)
        {
            JobVacancy jobRegistered = _jobVacancyRepository.FindById(jobId);
            request.Adapt(jobRegistered);
            AuditHelper.UpdateAuditInfo(jobRegistered, EntityState.Modified, GetName());
            await _jobVacancyRepository.UpdateAsync(jobRegistered);
        }

        public async Task RemoveJob(Guid jobId)
        {
            JobVacancy jobRegistered = _jobVacancyRepository.FindById(jobId);
            AuditHelper.UpdateAuditInfo(jobRegistered, EntityState.Deleted, GetName());
            await _jobVacancyRepository.UpdateAsync(jobRegistered);
        }

        public async Task HardRemoveJob(Guid jobId)
        {
            JobVacancy jobRegistered = _jobVacancyRepository.FindById(jobId);
            AuditHelper.UpdateAuditInfo(jobRegistered, EntityState.Deleted, GetName());
            await _jobVacancyRepository.RemoveAsync(jobRegistered);
        }

        public PaginationResponse<JobResume> GetPaginatedJobResumesPending(PaginationRequest request)
        {
            var pagination = _jobVacancyRepository.SearchJobPendingPaginated(request);
            var resumes = pagination.Data.Adapt<List<JobResume>>();
            return new PaginationResponse<JobResume>(request.PageIndex, request.PageSize, pagination.TotalPages, resumes);
        }

        public PaginationResponse<JobVacancy> GetPaginatedJobResumesAproved(PaginationRequest request)
        {
            return _jobVacancyRepository.SearchJobAprovedPaginated(request);
        }

        public async Task AproveJob(JobManagement request)
        {
            JobVacancy job = _jobVacancyRepository.FindById(request.Id);
            job.AdministrationStep = AdministrationStep.Aproved;
            await _jobVacancyRepository.UpdateAsync(job);
        }

        public async Task ReproveJob(JobManagement request)
        {
            JobVacancy job = _jobVacancyRepository.FindById(request.Id);
            job.AdministrationStep = AdministrationStep.Reproved;
            job.AdministrationDescription = request.Description;
            await _jobVacancyRepository.UpdateAsync(job);
        }

        public Task<JobVacancy> FindJobById(Guid jobId)
        {
            return Task.Run(() => _jobVacancyRepository.FindById(jobId));
        }

        public PaginationResponse<JobVacancy> GetPaginatedUserJobResumesAproved(PaginationRequest request)
        {
            return _jobVacancyRepository.SearchUserJobAprovedPaginated(request, GetLogin());
        }

        public PaginationResponse<JobVacancy> GetPaginatedUserJobResumesReproved(PaginationRequest request)
        {
            return _jobVacancyRepository.SearchUserJobReprovedPaginated(request, GetLogin());
        }
    }
}

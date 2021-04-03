using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Models.Pagination;
using FatecMauaJobNewsletter.Models.Request;
using FatecMauaJobNewsletter.Models.Response;
using System;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Services.Interfaces
{
    public interface IJobVacancyService
    {
        Task InsertJob(JobVacancyRequest request);

        Task UpdateJob(JobVacancyRequest request, Guid jobId);

        Task RemoveJob(Guid jobId);

        Task HardRemoveJob(Guid jobId);

        PaginationResponse<JobResume> GetPaginatedJobResumesPending(PaginationRequest request);

        PaginationResponse<JobVacancy> GetPaginatedJobResumesAproved(PaginationRequest request);

        PaginationResponse<JobVacancy> GetPaginatedUserJobResumesAproved(PaginationRequest request);

        PaginationResponse<JobVacancy> GetPaginatedUserJobResumesReproved(PaginationRequest request);

        Task AproveJob(JobManagement request);

        Task ReproveJob(JobManagement request);

        Task<JobVacancy> FindJobById(Guid jobId);
    }
}

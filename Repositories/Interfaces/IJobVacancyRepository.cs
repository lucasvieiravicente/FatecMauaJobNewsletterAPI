using FatecMauaJobNewsletter.Domains.Contexts.Interfaces;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Models.Pagination;

namespace FatecMauaJobNewsletter.Repositories.Interfaces
{
    public interface IJobVacancyRepository : IRepository<JobVacancy>
    {
        PaginationResponse<JobVacancy> SearchJobPendingPaginated(PaginationRequest request);

        PaginationResponse<JobVacancy> SearchJobAprovedPaginated(PaginationRequest request);

        PaginationResponse<JobVacancy> SearchUserJobAprovedPaginated(PaginationRequest request, string userLogin);

        PaginationResponse<JobVacancy> SearchUserJobReprovedPaginated(PaginationRequest request, string userLogin);
    }
}

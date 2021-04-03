using FatecMauaJobNewsletter.Domains.Contexts;
using FatecMauaJobNewsletter.Domains.Enums;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Models.Pagination;
using FatecMauaJobNewsletter.Repositories.Interfaces;
using System.Linq;

namespace FatecMauaJobNewsletter.Repositories
{
    public class JobVacancyRepository : Repository<JobVacancy>, IJobVacancyRepository
    {
        public JobVacancyRepository(DBContext context) : base(context)
        {
        }

        public PaginationResponse<JobVacancy> SearchJobPendingPaginated(PaginationRequest request)
        {
            var query = GetAllActive()
                                .Where(x => x.AdministrationStep == AdministrationStep.Pending)
                                .AsQueryable();

            return PagedSearch(query, request);
        }

        public PaginationResponse<JobVacancy> SearchJobAprovedPaginated(PaginationRequest request)
        {
            var query = GetAllActive()
                                .Where(x => x.AdministrationStep == AdministrationStep.Aproved)
                                .AsQueryable();

            return PagedSearch(query, request);
        }

        public PaginationResponse<JobVacancy> SearchUserJobAprovedPaginated(PaginationRequest request, string userLogin)
        {
            var query = GetAllActive()
                                .Where(x => x.UserCreated == userLogin)
                                .Where(x => x.AdministrationStep == AdministrationStep.Aproved)
                                .AsQueryable();

            return PagedSearch(query, request);
        }

        public PaginationResponse<JobVacancy> SearchUserJobReprovedPaginated(PaginationRequest request, string userLogin)
        {
            var query = GetAllActive()
                                .Where(x => x.UserCreated == userLogin)
                                .Where(x => x.AdministrationStep == AdministrationStep.Reproved)
                                .AsQueryable();

            return PagedSearch(query, request);
        }
    }
}

using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Models.Pagination;
using System.Collections.Generic;
using System.Linq;

namespace FatecMauaJobNewsletter.Contexts.Interfaces
{
    public interface ICustomSearch<T> where T : BaseEntity
    {
        IQueryable<T> Query();

        IEnumerable<T> GetAllActive();

        PaginationResponse<T> PagedSearch(IEnumerable<T> query, PaginationRequest request);
    }
}

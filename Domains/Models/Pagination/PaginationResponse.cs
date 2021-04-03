using FatecMauaJobNewsletter.Domains.Models;
using System.Collections.Generic;

namespace FatecMauaJobNewsletter.Models.Pagination
{
    public class PaginationResponse<T> where T : BaseEntity
    {
        public PaginationResponse()
        {
            Data = new List<T>();
        }

        public PaginationResponse(int page, int pageSize, int totalPages, IEnumerable<T> data)
        {
            Page = page;
            PageSize = pageSize;
            TotalPages = totalPages;
            Data = data;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}

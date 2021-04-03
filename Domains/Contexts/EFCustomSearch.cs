using FatecMauaJobNewsletter.Contexts.Interfaces;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FatecMauaJobNewsletter.Domains.Contexts
{
    public class EFCustomSearch<T> : ICustomSearch<T> where T : BaseEntity
    {
        private readonly DBContext _context;
        public EFCustomSearch(DBContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetAllActive()
        {
            return Query().Where(x => x.FlagActive);
        }

        public PaginationResponse<T> PagedSearch(IEnumerable<T> query, PaginationRequest request)
        {
            int pageSize = request.PageSize >= 1 ? request.PageSize : 1;
            int skipValues = GetValuesToSkip(request);
            int countLines = query.Count();
            int totalPages = GetTotalPages(countLines, pageSize);

            try
            {
                if (countLines > 0)
                {
                    var result = query.Skip(skipValues).Take(pageSize).ToList();
                    return new PaginationResponse<T>(request.PageIndex, pageSize, totalPages, result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new PaginationResponse<T>(request.PageIndex, pageSize, totalPages, new List<T>());
        }

        private int GetValuesToSkip(PaginationRequest request)
        {
            if (request.PageIndex <= 1)
                return 0;
            else
                return (request.PageIndex - 1) * request.PageSize;          
        }

        private int GetTotalPages(decimal lines, int pageSize)
        {
            if (lines <= 1)
                return 1;
            else          
                return (int) Math.Ceiling(lines / pageSize);               
        }
    }
}

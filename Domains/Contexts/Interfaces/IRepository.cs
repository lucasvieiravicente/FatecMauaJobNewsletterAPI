using FatecMauaJobNewsletter.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Domains.Contexts.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Query();

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllActive();

        T FindById(Guid id);

        IEnumerable<T> FindByIds(IEnumerable<Guid> ids);

        Task RemoveAsync(T model);

        Task RemoveAsync(IEnumerable<T> models);

        Task UpdateAsync(T model);

        Task UpdateAsync(IEnumerable<T> models);

        Task InsertAsync(T model);

        Task InsertAsync(IEnumerable<T> models);
    }
}

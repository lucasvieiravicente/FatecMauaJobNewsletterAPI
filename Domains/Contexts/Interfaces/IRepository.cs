using FatecMauaJobNewsletter.Contexts.Interfaces;
using FatecMauaJobNewsletter.Domains.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FatecMauaJobNewsletter.Domains.Contexts.Interfaces
{
    public interface IRepository<T> : ICustomSearch<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

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

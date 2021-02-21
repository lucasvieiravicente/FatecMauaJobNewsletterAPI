using FatecMauaJobNewsletter.Domains.Contexts.Interfaces;
using FatecMauaJobNewsletter.Domains.Models;

namespace FatecMauaJobNewsletter.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByLogin(string login, byte[] password);
    }
}

using FatecMauaJobNewsletter.Domains.Contexts.Interfaces;
using FatecMauaJobNewsletter.Domains.Models;

namespace FatecMauaJobNewsletter.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByLoginAndPassword(string login, byte[] password);

        User FindByLogin(string login);
    }
}

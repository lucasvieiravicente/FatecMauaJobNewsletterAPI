using FatecMauaJobNewsletter.Domains.Contexts;
using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Repositories.Interfaces;
using System.Linq;

namespace FatecMauaJobNewsletter.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        }

        public User FindByLogin(string login, byte[] password)
        {
            return Query()
                        .Where(x => x.Login.Equals(login) && x.Password.Equals(password))
                        .FirstOrDefault();
        }
    }
}

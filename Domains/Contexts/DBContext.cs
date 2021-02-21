using FatecMauaJobNewsletter.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace FatecMauaJobNewsletter.Domains.Contexts
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        DbSet<JobVacancy> JobVacancies { get; set; }
    }
}

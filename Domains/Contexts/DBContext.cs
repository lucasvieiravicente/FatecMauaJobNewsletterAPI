using FatecMauaJobNewsletter.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace FatecMauaJobNewsletter.Domains.Contexts
{
    public class DBContext : DbContext
    {
        public static readonly LoggerFactory _loggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobVacancy>()
                                        .Property(p => p.Salary)
                                        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<User>()
                                    .HasIndex(x => x.Login)
                                    .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        DbSet<JobVacancy> JobVacancies { get; set; }

        DbSet<User> Users { get; set; }
    }
}

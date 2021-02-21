using Microsoft.Extensions.DependencyInjection;
using FatecMauaJobNewsletter.Domains.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class StartupConfig
    {
        public static void ConfigureDatabaseConnectiton(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(x => x.UseSqlServer(configuration.GetConnectionString("Database")));
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using FatecMauaJobNewsletter.Domains.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FatecMauaJobNewsletter.Domains.Claims;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class StartupConfig
    {
        public static void ConfigureDatabaseConnectiton(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(x => x.UseSqlServer(configuration.GetConnectionString("Database")));
        }

        private static void AddAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(a =>
            {
                a.AddPolicy(UserClaim.Administration, x => x.RequireClaim("UserType", UserClaim.Administration));
                a.AddPolicy(UserClaim.Student, x => x.RequireClaim("UserType", UserClaim.Student));
            });
        }
    }
}

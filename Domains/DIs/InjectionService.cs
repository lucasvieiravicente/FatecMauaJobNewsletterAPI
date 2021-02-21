using FatecMauaJobNewsletter.Repositories;
using FatecMauaJobNewsletter.Repositories.Interfaces;
using FatecMauaJobNewsletter.Services;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FatecMauaJobNewsletter.Domains.DIs
{
    public class InjectionService
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            InjectServices(services);
            InjectRepositories(services);
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserLoginService, UserLoginService>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}

using FatecMauaJobNewsletter.Domains.Contexts;
using FatecMauaJobNewsletter.Domains.Contexts.Interfaces;
using FatecMauaJobNewsletter.Repositories;
using FatecMauaJobNewsletter.Repositories.Interfaces;
using FatecMauaJobNewsletter.Services;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IJobVacancyService, JobVacancyService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}

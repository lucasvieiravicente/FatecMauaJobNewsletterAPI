using FatecMauaJobNewsletter.Repositories;
using FatecMauaJobNewsletter.Repositories.Interfaces;
using FatecMauaJobNewsletter.Services;
using FatecMauaJobNewsletter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FatecMauaJobNewsletter.Domains.DIs
{
    public static class InjectionService
    {
        public static void InjectDependencies(this IServiceCollection services)
        {
            InjectServices(services);
            InjectRepositories(services);
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IJobVacancyService, JobVacancyService>();
            services.AddTransient<IUserLoginService, UserLoginService>();
            services.AddTransient<ICookiesService, CookiesService>();
            services.AddTransient<IPagesService, PagesService>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IJobVacancyRepository, JobVacancyRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}

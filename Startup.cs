using FatecMauaJobNewsletter.Domains.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mapster;
using FatecMauaJobNewsletter.Domains.DIs;

namespace FatecMauaJobNewsletter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfiguration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfiguration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            StartupConfig.ConfigureServices(services, Configuration);
            InjectionService.InjectDependencies(services);
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            StartupConfig.ConfigureSwagger(app);
        }
    }
}

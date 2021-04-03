using FatecMauaJobNewsletter.Domains.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mapster;
using FatecMauaJobNewsletter.Domains.DIs;
using FatecMauaJobNewsletter.Domains.Claims;
using System.Security.Claims;

namespace FatecMauaJobNewsletter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InjectDependencies();
            services.ConfigureServices(Configuration);
            AddServiceAuthorization(services);
            services.AddControllers();
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

        private void AddServiceAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(a =>
            {
                a.AddPolicy(UserClaim.Administration, x => x.RequireClaim(ClaimTypes.Role, UserClaim.Administration));
                a.AddPolicy(UserClaim.Student, x => x.RequireClaim(ClaimTypes.Role, UserClaim.Student));
                a.AddPolicy(UserClaim.AtLeastAuthenticated, x => x.RequireAssertion(x => x.User.HasClaim(x => x.Value == UserClaim.Student) ||
                                                                                         x.User.HasClaim(x => x.Value == UserClaim.Administration)));
            });
        }
    }
}

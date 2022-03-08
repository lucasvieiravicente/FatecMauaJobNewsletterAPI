using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FatecMauaJobNewsletter.Domains.Contexts;
using FatecMauaJobNewsletter.Domains.Claims;
using System.Security.Claims;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class StartupConfig
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddSwaggerGenInfo(services);
            AddAuthentication(services, configuration);
            AddAuthorization(services);
            ConfigureDatabaseConnectiton(services, configuration);
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FatecMauaJobNewsletter API v1");
            });
        }

        private static void ConfigureDatabaseConnectiton(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(x => x.UseMySQL(configuration.GetConnectionString("Database")));
        }

        private static void AddSwaggerGenInfo(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fatec Maua Job Newsletter API",
                    Description = "Api to control and populate the website FatecMauaJobNewsletter",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas V Vicente",
                        Email = "lucasvieiravicente1@gmail.com",
                        Url = new Uri("https://white-moss-0cf7e1e0f.azurestaticapps.net/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://github.com/lucasvieiravicente/FatecMauaJobNewsletterAPI")
                    },
                });
            });
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateAudience = false
                };
            });
        }

        private static void AddAuthorization(IServiceCollection services)
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

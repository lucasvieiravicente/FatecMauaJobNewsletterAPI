using Microsoft.Extensions.DependencyInjection;
using FatecMauaJobNewsletter.Domains.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FatecMauaJobNewsletter.Domains.Claims;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Builder;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class StartupConfig
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            AddAuthorization(services);
            AddSwaggerGenInfo(services);
            AddAuthentication(services, configuration);
            ConfigureDatabaseConnectiton(services, configuration);
        }

        public static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger(x => x.SerializeAsV2 = true);
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LoginService API v1");
            });
        }

        private static void ConfigureDatabaseConnectiton(IServiceCollection services, IConfiguration configuration)
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

        private static void AddSwaggerGenInfo(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
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
                    Title = "FatecMauaJobNewsletter API",
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
                        //Url = new Uri("inserir link da license do repositorio depois")
                    },
                });
            });
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };

            });
        }
    }
}

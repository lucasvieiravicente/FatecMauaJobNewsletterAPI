﻿using FatecMauaJobNewsletter.Domains.Models;
using FatecMauaJobNewsletter.Domains.Models.Request;
using FatecMauaJobNewsletter.Models.Response;
using Mapster;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class ConfigMapster
    {
        public static TypeAdapterConfig Configs()
        {
            var config = new TypeAdapterConfig();

            config.NewConfig<SignUpRequest, User>()
                                        .Map(src => src.Password, dest => HashUtil.HashPassword(dest.Password));

            config.NewConfig<User, UserUpdate>()
                                        .Ignore(x => x.Password);

            config.NewConfig<JobVacancy, JobResume>();

            return config;
        }
    }
}

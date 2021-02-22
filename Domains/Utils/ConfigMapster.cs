using FatecMauaJobNewsletter.Domains.Models;
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

            return config;
        }
    }
}

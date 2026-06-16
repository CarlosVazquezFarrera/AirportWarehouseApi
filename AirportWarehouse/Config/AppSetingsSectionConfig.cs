using AirportWarehouse.Core.ConfigOptions;

namespace AirportWarehouse.Config
{
    public static class AppSetingsSectionConfig
    {
        public static IServiceCollection AddAppSettingsSection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("Authentication"));
            services.Configure<DefaultPaginiationOptions>(configuration.GetSection("Pagination"));
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));

            return services;
        }
    }
}

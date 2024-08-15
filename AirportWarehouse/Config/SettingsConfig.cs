using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Service;
using Microsoft.Extensions.Configuration;
using System.Runtime;

namespace AirportWarehouse.Config
{
    public static class SettingsConfig
    {

        public static IServiceCollection AddConfigSettings(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton(provider =>
            {
            
                string? SecretKey = Environment.GetEnvironmentVariable("SecretKey");

                string Connection = Environment.GetEnvironmentVariable("ConnectionString") ?? configuration.GetConnectionString("DefaultConnection")!;

                return new ConfigSettings(
                    Connection,
                    SecretKey
                );
            });
            return services;
        }
    }
}

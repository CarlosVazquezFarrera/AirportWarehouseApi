using AirportWarehouse.Infrastructure.Data;
using AirportWarehouse.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
namespace AirportWarehouse.Config
{
    public static class DatabaseContext
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {

            ConfigSettings configSettings = services.BuildServiceProvider().GetRequiredService<ConfigSettings>();

            services.AddDbContext<AirportwarehouseContext>(options =>
            {
                options.UseNpgsql(connectionString: configSettings.ConnectionString);
            });
            return services;
        }
    }
}

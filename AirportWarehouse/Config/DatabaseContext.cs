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
                //options.UseNpgsql(connectionString: configSettings.ConnectionString);
                var conexion = "Host=viaduct.proxy.rlwy.net; Port=50490; Database=airportwarehouse_; Username=postgres; Password=tGyCmtNzbiXFcsLpDmYPAnpOAIqJIExA; Pooling=true;";
                options.UseNpgsql(conexion);
            });
            return services;
        }
    }
}

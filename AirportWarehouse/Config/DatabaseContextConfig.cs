using AirportWarehouse.Infrastructure.Data;
using AirportWarehouse.Utils.Helpers.Config;
using Microsoft.EntityFrameworkCore;
namespace AirportWarehouse.Config;

public static class DatabaseContextConfig
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
    {
        IConfigOptionsHelper configSettings = services.BuildServiceProvider().GetRequiredService<IConfigOptionsHelper>();
        services.AddDbContext<AirportwarehouseContext>(options => options.UseNpgsql(connectionString: configSettings.GetConnectionString()));
        return services;
    }
}

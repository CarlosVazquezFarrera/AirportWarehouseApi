using System.Text.Json.Serialization;
namespace AirportWarehouse.Config;

public static class ControllersConfig
{
    public static IServiceCollection AddControllerConfig(this IServiceCollection services)
    {
        //Add services to the container.
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                // options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
        return services;
    }
}

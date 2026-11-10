namespace AirportWarehouse.Config;

public static class CorsConfig
{
    public static IServiceCollection AddCorsConfig(this IServiceCollection services, string MyAllowSpecificOrigins)
    {
       services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                              policy =>
                              {
                                  policy
                                  .WithOrigins(
                                      "http://localhost:4200",
                                      "http://localhost:80",
                                      "http://localhost",
                                      "https://airportwarehouse.carlos-vazquez-unach.workers.dev/",
                                      "https://airportwarehouse.carlos-vazquez-unach.workers.dev",
                                      "https://airportwarehouse.vercel.app"
                                   )
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                              });
        });
        return services;
    }
}

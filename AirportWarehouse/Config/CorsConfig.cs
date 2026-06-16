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
                                      "http://137.184.230.117",
                                      "http://airportwarehouse.com.mx",
                                      "https://airportwarehouse.com.mx",
                                      "https://airportwarehouse.vercel.app"
                                   )
                                  .AllowAnyHeader()
                                  .AllowAnyMethod();
                              });
        });
        return services;
    }
}

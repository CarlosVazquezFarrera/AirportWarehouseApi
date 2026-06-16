using Microsoft.Extensions.Options;
using NSwag;

namespace AirportWarehouse.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddOpenApiDocument(options =>
            {

                options.AddSecurity("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Bearer token authorization header",
                    Type = OpenApiSecuritySchemeType.Http,
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Name = "Authorization",
                    Scheme = "Bearer"
                });
                options.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Warehouse API"
                    };
                };
            });
            return services;
        }
    }
}

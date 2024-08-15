using AirportWarehouse.Infrastructure.Configuration;
using AirportWarehouse.Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AirportWarehouse.Config
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJWTConfig(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigSettings configSettings = services.BuildServiceProvider().GetRequiredService<ConfigSettings>();

            services.Configure<JwtSettings>(configuration.GetSection("Authentication"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configSettings.SecretKey))
                };
            });
            return services;
        }
    }
}

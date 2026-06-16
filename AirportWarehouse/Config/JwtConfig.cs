using AirportWarehouse.Utils.Helpers.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AirportWarehouse.Config;

public static class JwtConfig
{
    public static IServiceCollection AddJWTConfig(this IServiceCollection services, IConfiguration configuration)
    {

        IConfigOptionsHelper configSettings = services.BuildServiceProvider().GetRequiredService<IConfigOptionsHelper>();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Authentication:Issuer"],
                ValidAudience = configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configSettings.GetSecretKey()))
            };
        });
        return services;
    }
}

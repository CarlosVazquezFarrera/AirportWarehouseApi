using AirportWarehouse.Infrastructure.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace AirportWarehouse.Config
{
    public static class ValidationConfig
    {
        public static IServiceCollection AddValidationConfig(this IServiceCollection services)
        {
            
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddFluentValidationAutoValidation();
            return services;
        }
    }
}

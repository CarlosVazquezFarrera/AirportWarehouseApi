using FluentValidation;
using FluentValidation.AspNetCore;

namespace AirportWarehouse.Config
{
    public static class ValidationConfig
    {
        public static IServiceCollection AddValidationConfig(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}

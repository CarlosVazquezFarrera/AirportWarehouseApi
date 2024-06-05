using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Helpers;
using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Repositories;
using AirportWarehouse.Infrastructure.Service;

namespace AirportWarehouse.Config
{

    public static class DepednencyConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherRepository, WeatherForecastRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepositoty<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtBearer, JwtBearerHelper>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IEgressService, EgressService>();
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}

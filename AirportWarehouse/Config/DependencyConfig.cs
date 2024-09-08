using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.Options;
using AirportWarehouse.Infrastructure.Helpers;
using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Options;
using AirportWarehouse.Infrastructure.Repositories;
using AirportWarehouse.Infrastructure.Service;

namespace AirportWarehouse.Config
{

    public static class DependencyConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepositoty<>));
            services.AddScoped(typeof(IPagedListService<>), typeof(PagedListService<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtBearer, JwtBearerHelper>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IEgressService, EgressService>();
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAgentService, AgentService>();


            services.AddSingleton<IPasswordService, PasswordService>();
            


            services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));

            return services;
        }
    }
}

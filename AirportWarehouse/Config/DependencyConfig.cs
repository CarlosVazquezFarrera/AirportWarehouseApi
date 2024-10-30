using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
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
            services.AddScoped(typeof(IEntityDtoService<,>), typeof(EntityDtoService<,>));
            services.AddScoped<IEntityDtoService<Egress, EgressDTO>, EgressService>();
            services.AddScoped<IEntityDtoService<Entry, EntryDTO>, EntryService>();



            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IClaimService, ClaimService>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddTransient<IJwtBearer, JwtBearerHelper>();
            services.AddScoped(typeof(IQueryService<>), typeof(QueryService<>));

            services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));

            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}

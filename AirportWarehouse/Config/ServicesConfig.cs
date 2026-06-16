using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.DataServices;
using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using AirportWarehouse.Infrastructure.Services;
using AirportWarehouse.Utils.Helpers.Claims;
using AirportWarehouse.Utils.Helpers.Config;
using AirportWarehouse.Utils.Helpers.Jwt;
using AirportWarehouse.Utils.Helpers.Password;

namespace AirportWarehouse.Config;

public static class ServicesConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IJwtBearerHelper, JwtBearerHelper>();
        services.AddScoped<IClaimHelper, ClaimHelper>();

        services.AddScoped<IConfigOptionsHelper, ConfigOptionsHelper>();

        services.AddScoped<IPassWordHelper, PassWordHelper>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));
        services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

        services.AddScoped<IGenericService<Entry, EntryDto>, EntryService>();
        services.AddScoped<IGenericService<Egress, EgressDto>, EgressService>();
        services.AddScoped<IProductService, ProductService>();

      


        return services;
    }

}

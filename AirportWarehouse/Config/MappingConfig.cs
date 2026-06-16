using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Utils.Mapper;
using AirportWarehouse.Utils.Mapper.Profiles;

namespace AirportWarehouse.Config;

public static class MappingConfig
{
    public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
    {
        services.AddScoped<IGenericMapper<Agent, AgentDto>, AgentMappingProfile>();
        services.AddScoped<IGenericMapper<Airport, AirportDto>, AirportMappingProfile>();
        services.AddScoped<IGenericMapper<Category, CategoryDto>, CategoryMappingProfile>();
        services.AddScoped<IGenericMapper<PackagingType, PackagingTypeDto>, PackagingTypeMappingProfile>();
        services.AddScoped<IGenericMapper<Presentation, PresentationDto>, PresentationMappingProfile>();
        services.AddScoped<IGenericMapper<ProductFormat, ProductFormatDto>, ProductFormatMappingProfile>();
        services.AddScoped<IGenericMapper<Product, ProductDto>, ProductMappingProfile>();
        services.AddScoped<IGenericMapper<Entry, EntryDto>, EntryMappingProfile>();
        services.AddScoped<IGenericMapper<Egress, EgressDto>, EgressMappingProfile>();
        services.AddScoped<IGenericMapper<Department, DepartmentDto>, DepartmentMappingProfile>();
        

        return services;
    }
}

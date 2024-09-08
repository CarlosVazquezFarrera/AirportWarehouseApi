using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Agent, AgentDTO>();
            CreateMap<AgentDTO, Agent>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
//.ForMember(dest => dest.Password, opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.Password)));

            CreateMap<Agent, AgentBaseInfo>().ReverseMap();
            CreateMap<AgentDTO, AgentBaseInfo>().ReverseMap();
  
            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<AgentPermission, AgentPermissionDTO>().ReverseMap();
            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<Egress, EgressDTO>().ReverseMap();
            CreateMap<Entry, EntryDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Supply, SupplyDTO>().ReverseMap();
        }
    }
}

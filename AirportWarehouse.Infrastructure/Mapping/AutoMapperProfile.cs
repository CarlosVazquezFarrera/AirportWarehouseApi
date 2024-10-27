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
            CreateMap<Agent, AgentDetailInfo>();
            CreateMap<AgentDetailInfo, AgentBaseInfo>().ReverseMap();
            CreateMap<AgentDTO, Agent>();
            CreateMap<AgentEditableInfo, Agent>()
               .ForMember(dest => dest.Password, opt => opt.Ignore());


            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<AgentPermission, AgentPermissionDTO>().ReverseMap();
            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<Egress, EgressDTO>().ReverseMap();
            CreateMap<Entry, EntryDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Stock,
                       opt => opt.MapFrom(src => src.FormatQuantity * src.PresentationQuantity));

            CreateMap<Supply, SupplyDTO>().ReverseMap();
            CreateMap<PackagingType, PackagingTypeDTO>().ReverseMap();
            CreateMap<Presentation, PresentationDTO>().ReverseMap();
            CreateMap<ProductFormat, ProductFormatDTO>().ReverseMap();
        }
    }
}

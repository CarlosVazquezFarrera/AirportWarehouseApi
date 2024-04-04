﻿using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Agent, AgentDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => (Guid?)null));
            CreateMap<Airport, AirportDTO>().ReverseMap();
            CreateMap<AgentDTO, Agent>();
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

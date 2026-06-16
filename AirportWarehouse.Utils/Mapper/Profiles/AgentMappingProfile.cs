using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Utils.Helpers.Jwt;
using AirportWarehouseAdminApi.Utils.Mapper;

namespace AirportWarehouse.Utils.Mapper.Profiles
{
    public class AgentMappingProfile : MappingProfile<Agent, AgentDto>
    {
        public AgentMappingProfile(IJwtBearerHelper jwtBearerHelper)
        {
            Map(dto => dto.Token, entity => jwtBearerHelper.GetJwtToken(entity.Name, entity.Email, entity.Id, entity.AirportId ?? Guid.Empty));
        }

    }
}

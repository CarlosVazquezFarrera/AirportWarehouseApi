using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Utils.Helpers.Jwt;

namespace AirportWarehouse.Utils.Mapper.Profiles
{
    public class AgentMappingProfile : MappingProfile<Agent, AgentDto>
    {
        public AgentMappingProfile(IJwtBearerHelper jwtBearerHelper)
        {
            IgnoreOnToDto(dto => dto.Id);
            Map(dto => dto.Token, entity => jwtBearerHelper.GetJwtToken(entity.Name, entity.Email, entity.Id, entity.AirportId!.Value));
        }

    }
}

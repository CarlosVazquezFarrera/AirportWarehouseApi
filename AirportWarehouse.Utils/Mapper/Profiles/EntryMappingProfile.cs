using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Utils.Helpers.Claims;

namespace AirportWarehouse.Utils.Mapper.Profiles;

public class EntryMappingProfile : MappingProfile<Entry, EntryDto>
{
    public EntryMappingProfile(IClaimHelper claimHelper)
    {
        MapToEntity(entity => entity.AgentId, _ => claimHelper.GetUserId());
    }
}

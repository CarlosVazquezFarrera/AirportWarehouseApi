using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Utils.Helpers.Claims;

namespace AirportWarehouse.Utils.Mapper.Profiles;

public class EgressMappingProfile : MappingProfile<Egress, EgressDto>
{
    public EgressMappingProfile(IClaimHelper claimHelper)
    {
        MapToEntity(entity => entity.ApproverId, _ => claimHelper.GetUserId());
    }
}

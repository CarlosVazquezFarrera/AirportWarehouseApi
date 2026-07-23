using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Utils.Helpers.Claims;

namespace AirportWarehouse.Utils.Mapper.Profiles;

public class EgressMappingProfile : MappingProfile<Egress, EgressDto>
{
    public EgressMappingProfile(IClaimHelper claimHelper)
    {
        Map(dto => dto.ProductName, entity => entity.Product.Name);
        Map(dto => dto.ApproverName, entity => string.Concat(entity.Approver.Name," ", entity.Approver.LastName));

        MapToEntity(entity => entity.ApproverId, _ => claimHelper.GetUserId());
    }
}

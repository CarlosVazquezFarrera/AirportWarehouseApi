using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.ParamerEntities;
using AirportWarehouseAdminApi.Core.CustomEntities;

namespace AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

public interface IEgressService : IGenericService<Egress, EgressDto>
{
    Task<PagedResult<LedgerEgressMovement>> CountUnitRemoved(PaginationsParams paginations, DateOnly ? date);
}

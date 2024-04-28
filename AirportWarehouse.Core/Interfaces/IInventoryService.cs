using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.ExtentionEntities;
using AirportWarehouse.Core.QueryFilter;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IInventoryService
    {
        PagedResponse<InventoryItem> GetIventoryByAirport(InventoryParameters inventoryParameters);
        Task<InventoryItem> GetSuplyByIdAndAirport(Guid IdSupply, Guid IdAirport);
    }
}

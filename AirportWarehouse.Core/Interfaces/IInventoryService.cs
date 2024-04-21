using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.QueryFilter;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IInventoryService
    {
        IEnumerable<InventoryItem> GetIventoryByAirport(InventoryParameters inventoryParameters);
    }
}

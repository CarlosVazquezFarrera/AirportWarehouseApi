using AirportWarehouse.Core.CustomEntities;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IInventoryRepository 
    {
        IEnumerable<InventoryItem> GetIventoryByAirport(Guid IdAirport);
    }
}

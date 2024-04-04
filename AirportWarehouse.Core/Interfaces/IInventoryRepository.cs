using AirportWarehouse.Core.CustomEntities;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IInventoryRepository 
    {
        Task<IEnumerable<InventoryItem>> GetIventoryByAirport(Guid IdAirport);
    }
}

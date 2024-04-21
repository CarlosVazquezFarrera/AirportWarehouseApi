using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using System.Linq;

namespace AirportWarehouse.Infrastructure.Service
{
    public class InventoryService : IInventoryService
    {
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        private readonly IInventoryRepository _inventoryRepository;

        public IEnumerable<InventoryItem> GetIventoryByAirport(InventoryParameters inventoryParameters)
        {
            var inventoryItems = _inventoryRepository.GetIventoryByAirport(inventoryParameters.IdAiport);
            if (!String.IsNullOrEmpty(inventoryParameters.Search))
            {
                inventoryItems = inventoryItems.Where(i => 
                i.Name.Contains(inventoryParameters.Search.ToLower(), StringComparison.CurrentCultureIgnoreCase) || 
                i.SupplierPart.Contains(inventoryParameters.Search, StringComparison.CurrentCultureIgnoreCase));
            }
            return inventoryItems;
        }
    }
}

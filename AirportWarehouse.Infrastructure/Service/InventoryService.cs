using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;

namespace AirportWarehouse.Infrastructure.Service
{
    public class InventoryService : IInventoryService
    {
        public InventoryService(IInventoryRepository inventoryRepository, IPagedListService<InventoryItem> pagedListService)
        {
            _inventoryRepository = inventoryRepository;
            _pagedListService = pagedListService;
        }
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IPagedListService<InventoryItem> _pagedListService;

        public PagedResponse<InventoryItem> GetIventoryByAirport(InventoryParameters inventoryParameters)
        {
            var inventoryItems = _inventoryRepository.GetIventoryByAirport(inventoryParameters.IdAiport);
            if (!String.IsNullOrEmpty(inventoryParameters.Search))
            {
                inventoryItems = inventoryItems.Where(i =>
                i.Name.Contains(inventoryParameters.Search.ToLower(), StringComparison.CurrentCultureIgnoreCase) ||
                i.SupplierPart!.Contains(inventoryParameters.Search, StringComparison.CurrentCultureIgnoreCase));
            }
            var pagedResponse = _pagedListService.Paginate(inventoryItems, inventoryParameters.PageNumber, inventoryParameters.PageSize);
            return pagedResponse;
        }

        public async Task<InventoryItem> GetSuplyByIdAndAirport(Guid IdSupply)
        {
            return await _inventoryRepository.GetSuplyByIdAndAirport(IdSupply);
        }
    }
}

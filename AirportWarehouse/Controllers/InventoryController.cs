using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        private readonly IInventoryService _inventoryService;

        [HttpGet]
        public IActionResult GetInventoryByAirpot([FromQuery]InventoryParameters inventoryParameters)
        {
            PagedResponse<InventoryItem> inventory = _inventoryService.GetIventoryByAirport(inventoryParameters);
             return Ok(inventory);   
        }
        [HttpGet("GetSuplyByIdAndAirport")]
        public async Task<IActionResult> GetSuplyByIdAndAirport(Guid IdSupply, Guid IdAirport)
        {
            InventoryItem item = await _inventoryService.GetSuplyByIdAndAirport(IdSupply, IdAirport);
            return Ok(item);
        }
    }
}

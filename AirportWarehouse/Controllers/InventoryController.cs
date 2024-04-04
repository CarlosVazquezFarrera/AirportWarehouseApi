using AirportWarehouse.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InventoryController : ControllerBase
    {
        public InventoryController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        private readonly IInventoryRepository _inventoryRepository;

        [HttpGet]
        public async Task<IActionResult> GetInventoryByAirpot([FromQuery]Guid Id)
        {
            var inventory = await _inventoryRepository.GetIventoryByAirport(Id);
            return Ok(inventory);   
        }
    }
}

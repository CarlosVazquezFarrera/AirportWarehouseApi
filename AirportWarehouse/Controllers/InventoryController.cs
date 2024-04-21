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
        public IActionResult GetInventoryByAirpot([FromQuery]Guid Id)
        {
            var inventory = _inventoryRepository.GetIventoryByAirport(Id);
            return Ok(inventory);   
        }
    }
}

using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntryController : ControllerBase
    {
        public EntryController(IEntityDtoService<Entry, EntryDTO> entityDtoService)
        {
            _entityDtoService = entityDtoService;
        }

        private readonly IEntityDtoService<Entry, EntryDTO> _entityDtoService;

        [HttpPost]
        public async Task<IActionResult> CreateEntry(EntryDTO entryDto) {
            return Ok(await _entityDtoService.UpdateAsync(entryDto));
        }
    }
}

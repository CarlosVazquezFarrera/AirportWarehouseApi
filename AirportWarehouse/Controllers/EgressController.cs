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
    public class EgressController : ControllerBase
    {
        public EgressController(IEntityDtoService<Egress, EgressDTO> entityDtoService)
        {
            _entityDtoService = entityDtoService;
        }

        private readonly IEntityDtoService<Egress, EgressDTO> _entityDtoService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EgressDTO egress) {
            return Ok(await _entityDtoService.AddAsync(egress));
        }
    }
}

using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplyController : ControllerBase
    {
        public SupplyController(IEntityDtoService<Supply, SupplyDTO> entityDtoService)
        {
            _entityDtoService = entityDtoService;
        }

        private readonly IEntityDtoService<Supply, SupplyDTO> _entityDtoService;
        [HttpGet]
        public async Task<IActionResult> Get(Guid Id)
        {
            return Ok(await _entityDtoService.GetByIdAsync(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplyDTO supplyDTO)
        {
            return Ok(await _entityDtoService.AddAsync(supplyDTO));
        }
    }
}

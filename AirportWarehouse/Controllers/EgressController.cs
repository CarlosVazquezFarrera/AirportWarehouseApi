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
    public class EgressController : ControllerBase
    {
        public EgressController(IEntityDtoService<Egress, EgressDTO> egressService)
        {
            _egressService = egressService;
        }

        private readonly IEntityDtoService<Egress, EgressDTO> _egressService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EgressDTO egress) {
            return Ok(await _egressService.AddAsync(egress));
        }
    }
}

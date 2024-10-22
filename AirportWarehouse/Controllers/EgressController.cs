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
        public EgressController(IEgressService egressService, IMapper mapper)
        {
            _egressService = egressService;
            _mapper = mapper;
        }

        private readonly IEgressService _egressService;
        private readonly IMapper _mapper;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EgressDTO egress) {
            var egressDTO = _mapper.Map<EgressDTO>(await _egressService.AddAsync(egress));
            return Ok(egressDTO);
        }
    }
}

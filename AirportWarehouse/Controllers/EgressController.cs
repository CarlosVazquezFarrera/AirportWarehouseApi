using AirportWarehouse.Core.DTOs;
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
        public EgressController(IEgressService egressService)
        {
            _egressService = egressService;
        }

        private readonly IEgressService _egressService;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IEnumerable<EgressDTO> egresses) {
            try
            {
                return Ok(await _egressService.CreateEgressOrder(egresses));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
    }
}

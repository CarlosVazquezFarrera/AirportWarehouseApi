using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgentController : ControllerBase
    {
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        private readonly IAgentService _agentService;


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_agentService.GetAllAgentsWithoutAdmin());
        }

        [HttpGet("GetPagedAgents")]
        public IActionResult GetPagedAgents([FromQuery] AgentParameters agentParameters)
        {
            return Ok(_agentService.GetPagedAgents(agentParameters));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgentDTO agentDTO)
        {
            return Ok(await _agentService.AddAsync(agentDTO));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AgentEditableInfo agentDTO)
        {
            return Ok(await _agentService.UpdateAsync(agentDTO));
        }
    }
    
}

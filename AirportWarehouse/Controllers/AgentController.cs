using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgentController : ControllerBase
    {
        public AgentController(IAgentService agentService, IMapper mapper)
        {
            _agentService = agentService;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        private readonly IAgentService _agentService;


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_agentService.GetAll());
        }

        [HttpGet("GetPagedAgents")]
        public IActionResult GetPagedAgents([FromQuery] AgentParameters agentParameters)
        {
            return Ok(_agentService.GetPagedAgents(agentParameters));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgentDTO agentDTO)
        {
            return Ok(await _agentService.Register(agentDTO));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AgentDTO agentDTO)
        {
            return Ok(await _agentService.Update(agentDTO));
        }

        [HttpPatch("SetPassword")]
        public async Task<IActionResult> SetPassword([FromBody] AgentPasswordInfo passwordInfo)
        {
            return Ok(await _agentService.SetPassword(passwordInfo));
        }
    }
}

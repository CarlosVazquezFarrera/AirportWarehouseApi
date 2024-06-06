using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
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
            IEnumerable<Agent> agents = _agentService.GetAll();
            return Ok(_mapper.Map<IEnumerable<AgentBaseInfo>>(agents));
        }

        [HttpGet("GetPagedAgents")]
        public IActionResult GetPagedAgents([FromQuery] AgentParameters agentParameters)
        {
            PagedResponse<AgentBaseInfo> agents = _agentService.GetPagedAgents(agentParameters);
            return Ok(agents);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgentDTO agentDTO)
        {
            var agent = await _agentService.Register(_mapper.Map<Agent>(agentDTO));
            return Ok(_mapper.Map<AgentBaseInfo>(agent));
        }


    }
}

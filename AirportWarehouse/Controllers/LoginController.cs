using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController(IJwtBearer jwt, IAgentRepository agentRepository, IMapper mapper)
        {
            _agentRepository = agentRepository;
            _jwt = jwt;
            _mapper = mapper;
        }

        private readonly IJwtBearer _jwt;
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;   

        [HttpPost]
        public async  Task<IActionResult> Login([FromBody] AgentLogin user)
        {
            var agent = await this._agentRepository.Login(user);
            if (agent == null)
            {
                return NotFound();
            }
            var agentInfo = new AgentInfo() {
                Agent = _mapper.Map<AgentDTO>(agent),
                Token = _jwt.GetJwtToken(agent.Name, agent.Email)
            };

            return Ok(agentInfo);
        }
    }
}

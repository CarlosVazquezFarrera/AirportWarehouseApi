using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController(IJwtBearer jwt, ILoginService agentRepository, IMapper mapper, IPasswordService passwordService)
        {
            _agentRepository = agentRepository;
            _jwt = jwt;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        private readonly IJwtBearer _jwt;
        private readonly ILoginService _agentRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AgentLogin user)
        {
            AgentDTO exitingAgent = await this._agentRepository.Login(user);

            _passwordService.Check(exitingAgent.Password, user.Password);

            var loginaAgent = _mapper.Map<AgentBaseInfo>(exitingAgent);

            var agentInfo = new AgentInfo() {
                Agent = loginaAgent,
                Token = _jwt.GetJwtToken(exitingAgent.Name, exitingAgent.Email, exitingAgent.Id)
            };

            return Ok(agentInfo);
        }
    }
}

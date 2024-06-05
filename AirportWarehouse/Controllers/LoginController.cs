using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
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
        public LoginController(IJwtBearer jwt, IAgentRepository agentRepository, IMapper mapper, IPasswordService passwordService)
        {
            _agentRepository = agentRepository;
            _jwt = jwt;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        private readonly IJwtBearer _jwt;
        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AgentLogin user)
        {
            Agent agentAdmin = await this._agentRepository.Login(user) ?? throw new CredentialsException("Check your credentials");

            if(!_passwordService.Check(agentAdmin.Password, user.Password))
                throw new CredentialsException("Check your credentials");
            var loginaAgent = _mapper.Map<LoginAgent>(agentAdmin);

            var agentInfo = new AgentInfo() {
                Agent = loginaAgent,
                Token = _jwt.GetJwtToken(agentAdmin.Name, agentAdmin.Email, agentAdmin.Id)
            };

            return Ok(agentInfo);
        }
    }
}

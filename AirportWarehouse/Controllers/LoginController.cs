﻿using AirportWarehouse.Core.CustomEntities;
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
        public LoginController(IJwtBearer jwt, IAgentService agentRepository, IMapper mapper)
        {
            _agentRepository = agentRepository;
            _jwt = jwt;
            _mapper = mapper;
        }

        private readonly IJwtBearer _jwt;
        private readonly IAgentService _agentRepository;
        private readonly IMapper _mapper;

        [HttpPost]
        public  IActionResult Login([FromBody] AgentLogin user)
        {
            AgentDetailInfo exitingAgent = this._agentRepository.Login(user);

            var agentInfo = new AgentInfo() {
                Agent = _mapper.Map<AgentBaseInfo>(exitingAgent),
                Token = _jwt.GetJwtToken(exitingAgent.Name, 
                exitingAgent.Email, 
                exitingAgent.Id,
                exitingAgent.AirportId)
            };

            return Ok(agentInfo);
        }
    }
}

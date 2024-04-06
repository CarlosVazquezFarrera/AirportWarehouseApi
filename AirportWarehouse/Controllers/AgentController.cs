using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        public AgentController(IRepository<Agent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private readonly IRepository<Agent> _repository;
        private readonly IMapper _mapper;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agents = await _repository.GetAll();
            var agentsDTO = _mapper.Map<IEnumerable<AgentDTO>>(agents);
            return Ok(agentsDTO);
        }
    }
}

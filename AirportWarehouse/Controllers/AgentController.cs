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
        public AgentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        [HttpGet]
        public IActionResult Get()
        {
            var agents = _unitOfWork.AgentRepository.GetAll();
            var agentsDTO = _mapper.Map<IEnumerable<AgentDTO>>(agents);
            return Ok(agentsDTO);
        }
    }
}

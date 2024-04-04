using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AirportController : ControllerBase
    {
        public AirportController(IRepository<Airport> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private readonly IRepository<Airport> _repository;
        private readonly IMapper _mapper;


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var airports = await _repository.GetAll();
            var airpotsDTO = _mapper.Map<IEnumerable<AirportDTO>>(airports);
            return Ok(airpotsDTO);
 
        }
    }
}

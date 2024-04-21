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
        public AirportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        [HttpGet]
        public IActionResult GetAll()
        {
            var airports = _unitOfWork.AirportRepository.GetAll();
            var airpotsDTO = _mapper.Map<IEnumerable<AirportDTO>>(airports);
            return Ok(airpotsDTO);
 
        }
    }
}

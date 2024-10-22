using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AirportController : ControllerBase
    {
        public AirportController(IEntityDtoService<Airport, AirportDTO> airportService)
        {
            _airportService = airportService;
        }

        private readonly IEntityDtoService<Airport, AirportDTO> _airportService;


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_airportService.GetAll());
        }
    }
}

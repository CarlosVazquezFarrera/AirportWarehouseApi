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
    public class PresentationController : ControllerBase
    {
        public PresentationController(IEntityDtoService<Presentation, PresentationDTO> presentation)
        {
            _entityDtoService = presentation;
        }

        private readonly IEntityDtoService<Presentation, PresentationDTO> _entityDtoService;


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_entityDtoService.GetAll());
        }
    }
}

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
    public class DepartmentController : ControllerBase
    {
        public DepartmentController(IEntityDtoService<Department, DepartmentDTO> entityDtoService)
        {
            _entityDtoService = entityDtoService;
        }
        private readonly IEntityDtoService<Department, DepartmentDTO> _entityDtoService;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_entityDtoService.GetAll());
        }

    }
}

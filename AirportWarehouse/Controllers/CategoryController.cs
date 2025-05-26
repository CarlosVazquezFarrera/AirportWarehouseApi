using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CategoryController : ControllerBase
    {
        public CategoryController(IEntityDtoService<Category, CategoryDTO> entityDtoService)
        {
            _entityDtoService = entityDtoService;
        }
        private readonly IEntityDtoService<Category, CategoryDTO> _entityDtoService;

        [HttpGet]
        public IActionResult PoductFormats()
        {
            return Ok(_entityDtoService.GetAll());
        }
    }
}

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
    public class PackagingTypeController : ControllerBase
    {
        public PackagingTypeController(IEntityDtoService<PackagingType, PackagingTypeDTO> packagingType)
        {
            _packagingType = packagingType;
        }

        private readonly IEntityDtoService<PackagingType, PackagingTypeDTO> _packagingType;

        [HttpGet]
        public IActionResult Get() {
            return Ok( _packagingType.GetAll());
        }
    }
}

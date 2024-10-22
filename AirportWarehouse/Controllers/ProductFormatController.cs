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
    public class ProductFormatController : ControllerBase
    {
        public ProductFormatController(IEntityDtoService<ProductFormat, ProductFormatDTO> productFormat)
        {
            _productFormat = productFormat;
        }

        private readonly IEntityDtoService<ProductFormat, ProductFormatDTO> _productFormat;


        [HttpGet]
        public IActionResult PoductFormats()
        {
            return Ok(_productFormat.GetAll());
        }
    }
}

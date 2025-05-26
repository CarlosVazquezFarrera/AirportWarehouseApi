using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        private readonly IProductService _productService;

        [HttpGet("GetProductsPagedByAirport")]
        public IActionResult GetAll([FromQuery] ProductsFilter parameters)
        {
            return Ok(_productService.GetProdcutsByAirport(parameters));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO product)
        {
            return Ok(await _productService.AddAsync(product));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDTO product) {
            return Ok(await _productService.UpdateAsync(product));
        }
    }
}

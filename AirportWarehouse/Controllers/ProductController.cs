using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        public ProductController(IMapper mapper, IPagedListService<ProductDTO> pagedListService, IProductService productService)
        {
            _mapper = mapper;
            _pagedListService = pagedListService;
            _productService = productService;
        }

        private readonly IMapper _mapper;
        private readonly IPagedListService<ProductDTO> _pagedListService;
        private readonly IProductService _productService;

        [HttpGet]
        public IActionResult GetAll([FromQuery] BasePagedParameter parameters)
        {
            var produtsDto = _mapper.Map<IEnumerable<ProductDTO>>(_productService.GetAll());
            var pagedResponse = _pagedListService.Paginate(produtsDto, parameters.PageNumber, parameters.PageSize);
            return Ok(pagedResponse);
        }

        [HttpGet("GetProductsMissingInAirport")]
        public IActionResult GetProductsMissingInAirport(Guid IdAirport)
        {
            IEnumerable<ProductDTO> productsMissingInAirport = _mapper.Map<IEnumerable< ProductDTO >>(_productService.GetProductsMissingInAirport(IdAirport));
            return Ok(productsMissingInAirport);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO product)
        {
            var newProduct = await _productService.CreateProduct(_mapper.Map<Product>(product));
            var productDto = _mapper.Map<ProductDTO>(newProduct);
            return Ok(productDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDTO product) {
            var newProduct = await _productService.UpdateProduct(_mapper.Map<Product>(product));
            var productDto = _mapper.Map<ProductDTO>(newProduct);
            return Ok(productDto);
        }
    }
}

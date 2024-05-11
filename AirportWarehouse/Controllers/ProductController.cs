using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;
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
        public ProductController(IUnitOfWork UnitOfWork, IMapper mapper, IPagedListService<ProductDTO> pagedListService)
        {
            _unitOfWork = UnitOfWork;
            _mapper = mapper;
            _pagedListService = pagedListService;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPagedListService<ProductDTO> _pagedListService;

        [HttpGet]
        public IActionResult GetAll([FromQuery] BasePagedParameter parameters)
        {
            var produtsDto = _mapper.Map<IEnumerable<ProductDTO>>(_unitOfWork.ProductRepository.GetAll());
            var pagedResponse = _pagedListService.Paginate(produtsDto, parameters.PageNumber, parameters.PageSize);
            return Ok(pagedResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO product)
        {
            await _unitOfWork.ProductRepository.Add(_mapper.Map<Product>(product));
            var productDto = _mapper.Map<ProductDTO>(product);
            return Ok(productDto);
        }
    }
}

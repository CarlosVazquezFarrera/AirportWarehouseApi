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
    public class SupplyController : ControllerBase
    {
        public SupplyController(IRepository<Supply> supplyRepository, IMapper mapper)
        {
            _supplyRepository = supplyRepository;
            _mapper = mapper;
        }

        private readonly IRepository<Supply> _supplyRepository;
        private readonly IMapper _mapper;
        [HttpGet]
        public async Task<IActionResult> Get(Guid Id)
        {
            var supply = await _supplyRepository.GetById(Id);
            var supplDto = _mapper.Map<SupplyDTO>(supply);
            return Ok(supplDto);
        }
    }
}

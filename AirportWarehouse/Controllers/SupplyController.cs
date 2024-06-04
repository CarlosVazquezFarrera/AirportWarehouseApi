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
        public SupplyController(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _iUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        IUnitOfWork _iUnitOfWork;
        private readonly IMapper _mapper;
        [HttpGet]
        public async Task<IActionResult> Get(Guid Id)
        {
            var supply = await _iUnitOfWork.SupplyRepository.GetById(Id);
            var supplyDto = _mapper.Map<SupplyDTO>(supply);
            return Ok(supplyDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplyDTO supplyDTO)
        {
            var supply = _mapper.Map<Supply>(supplyDTO);
            await _iUnitOfWork.SupplyRepository.Add(supply);
            await _iUnitOfWork.SaveChanguesAsync();
            return Ok(supply);
        }
    }
}

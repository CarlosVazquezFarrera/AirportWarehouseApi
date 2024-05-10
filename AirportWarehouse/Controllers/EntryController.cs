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
    public class EntryController : ControllerBase
    {
        public EntryController(IEntryService entryService, IMapper mapper)
        {
            _entryService = entryService;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        private readonly IEntryService _entryService;

        [HttpPost]
        public async Task<IActionResult> CreateEntry(EntryDTO entry) {
            var entrySaved = await _entryService.Create(_mapper.Map<Entry>(entry));
            var entrySavedDto = _mapper.Map<EntryDTO>(entrySaved);
            return Ok(entrySavedDto);
        }
    }
}

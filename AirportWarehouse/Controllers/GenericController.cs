using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AirportWarehouse.Controllers
{
    public abstract class GenericController<TEntity, TDto> : GenericGetController<TEntity, TDto> where TDto : BaseDto where TEntity : BaseEntity
    {
        protected GenericController(IGenericService<TEntity, TDto> service) : base(service)
        {
        }

        [HttpPost]
        public async Task<ActionResult<TDto>> Create([FromBody] TDto dto)
        {
            var newEntity = await _service.CreateAsync(dto).ConfigureAwait(false);
            return Created(string.Empty, newEntity);
        }

        [HttpPost("List")]
        public async Task<ActionResult<TDto>> CreateList([FromBody] IEnumerable<TDto> dtos)
        {
            var newEntities = await _service.CreateListAsync(dtos).ConfigureAwait(false);
            return Created(string.Empty, newEntities);
        }

        [HttpPut]
        public async Task<ActionResult<TDto>> Update([FromBody] TDto dto)
        {
            var updatedEntity = await _service.UpdateAsync(dto).ConfigureAwait(false);
            return updatedEntity is null ? NotFound() : Ok(updatedEntity);
        }
    }
}

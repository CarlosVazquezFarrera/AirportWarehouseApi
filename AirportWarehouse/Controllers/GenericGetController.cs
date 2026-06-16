using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.ParamerEntities;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AirportWarehouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class GenericGetController <TEntity, TDto> : ControllerBase where TDto : BaseDto where TEntity : BaseEntity
    {
        protected GenericGetController(IGenericService<TEntity, TDto> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDto>>> GetAll()
        {
            var includes = BuildIncludes();
            var result = await _service.GetAllAsync(includes).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<TDto>>> GetPaged([FromQuery] PaginationsParams paginations)
        {
            var filter = BuildFilter();
            var includes = BuildIncludes();
            var pagedResult = await _service.GetPagedAsync(paginations, filter, includes).ConfigureAwait(false);
            return Ok(pagedResult);
        }

        protected readonly IGenericService<TEntity, TDto> _service;

        protected virtual Expression<Func<TDto, bool>>? BuildFilter() => null;

        protected virtual IEnumerable<Expression<Func<TEntity, object>>>? BuildIncludes() => null;
    }
}

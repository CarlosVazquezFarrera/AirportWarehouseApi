using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.ParamerEntities;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AirportWarehouse.Controllers
{
    public class EgressController : GenericController<Egress, EgressDto>
    {
        public EgressController(IEgressService service) : base(service)
        {
           _egressService = service;
        }
        [FromQuery] public DateOnly? StartDate { get; set; }
        [FromQuery] public DateOnly? EndDate { get; set; }
        
        private readonly IEgressService _egressService;

        [HttpGet("TotalUnitRemoved")]
        public async Task<ActionResult> CountTotalEgressMovement([FromQuery] PaginationsParams paginations, [FromQuery] DateOnly? Date)
        {
            var result = await _egressService.CountUnitRemoved(paginations, Date);
            return Ok(result);
        }



        protected override Expression<Func<EgressDto, bool>>? BuildFilter()
        {
            if (!StartDate.HasValue || !EndDate.HasValue)
                return null;

            var start = StartDate.Value.ToDateTime(TimeOnly.MinValue);
            var end = EndDate.Value.ToDateTime(TimeOnly.MinValue).AddDays(1);
            return e => (!StartDate.HasValue || e.Date >= start)
                && (!EndDate.HasValue || e.Date <= end);
        }  
        protected override IEnumerable<Expression<Func<Egress, object>>>? BuildIncludes()
        => [
            e => e.Product,
            e => e.Approver,
        ];

    }
}

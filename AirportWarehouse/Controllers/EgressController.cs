using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.ParamerEntities;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using AirportWarehouse.Utils.Helpers.Claims;
using AirportWarehouse.Utils.Helpers.Extension;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AirportWarehouse.Controllers
{
    public class EgressController : GenericController<Egress, EgressDto>
    {
        public EgressController(IEgressService service, IClaimHelper claimHelper) : base(service)
        {
           _egressService = service;
            _claimHelper = claimHelper;
        }
        [FromQuery] public DateOnly? StartDate { get; set; }
        [FromQuery] public DateOnly? EndDate { get; set; }
        
        private readonly IEgressService _egressService;
        private readonly IClaimHelper _claimHelper;

        [HttpGet("TotalUnitRemoved")]
        public async Task<ActionResult> CountTotalEgressMovement([FromQuery] PaginationsParams paginations, [FromQuery] DateOnly? Date)
        {
            var result = await _egressService.CountUnitRemoved(paginations, Date);
            return Ok(result);
        }



        protected override Expression<Func<EgressDto, bool>>? BuildFilter()
        {
            Guid AirportId = _claimHelper.GetAirportId();

            DateTime? start = null;
            DateTime? end = null;

            if (StartDate.HasValue)
                start = StartDate.MinValue();

            if (EndDate.HasValue)
                end = EndDate.MinValue().AddDays(1);

            return e => e.AirportId == AirportId
                && (!start.HasValue || e.Date >= start.Value)
                && (!end.HasValue || e.Date <= end.Value); 
        }  
        protected override IEnumerable<Expression<Func<Egress, object>>>? BuildIncludes()
        => [
            e => e.Product,
            e => e.Approver,
        ];

    }
}

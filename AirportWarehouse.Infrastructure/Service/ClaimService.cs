using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AirportWarehouse.Infrastructure.Service
{
    public class ClaimService : IClaimService
    {
        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private readonly IHttpContextAccessor _httpContextAccessor;


        Guid IClaimService.GetUserId()
        {
            var user = _httpContextAccessor.HttpContext!.User;
            var Id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Id == null ? throw new CredentialsException() : new Guid(Id);
        }

        public Guid GetAirpotId()
        {
            var user = _httpContextAccessor!.HttpContext!.User;
            var airportId = user.FindFirst("AirportId")?.Value ?? throw new CredentialsException();
            return new Guid(airportId);
        }
    }
}

using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AirportWarehouse.Utils.Helpers.Claims;
public class ClaimHelper : IClaimHelper
{
    public ClaimHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    private readonly IHttpContextAccessor _httpContextAccessor;


    Guid IClaimHelper.GetUserId()
    {
        var user = _httpContextAccessor.HttpContext!.User;
        var Id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Id == null ? throw new CredentialsException() : new Guid(Id);
    }

    public Guid GetAirportId()
    {
        var user = _httpContextAccessor!.HttpContext!.User;
        var airportId = user.FindFirst("AirportId")?.Value ?? throw new CredentialsException();
        return new Guid(airportId);
    }
}
namespace AirportWarehouse.Utils.Helpers.Jwt;

public interface IJwtBearerHelper
{
    string GetJwtToken(string Name, string Email, Guid Id, Guid AirportId);
}

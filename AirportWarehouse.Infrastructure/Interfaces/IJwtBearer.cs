namespace AirportWarehouse.Infrastructure.Interfaces
{
    public interface IJwtBearer
    {
        string GetJwtToken(string Name, string Email, Guid Id);
    }
}

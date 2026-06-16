using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Request;

namespace AirportWarehouse.Infrastructure.Interfaces;

public interface ILoginService
{
    Task<AgentDto?> Login(LoginRequest user);
}

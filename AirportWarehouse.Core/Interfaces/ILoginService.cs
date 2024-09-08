using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;

namespace AirportWarehouse.Core.Interfaces
{
    public interface ILoginService 
    {
        Task<AgentDTO> Login(AgentLogin agent);
    }
}

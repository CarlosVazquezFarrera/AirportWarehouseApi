using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface ILoginService 
    {
        Task<Agent?> Login(AgentLogin agent);
    }
}

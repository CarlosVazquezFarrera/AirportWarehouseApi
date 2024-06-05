using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IAgentRepository 
    {
        Task<Agent?> Login(AgentLogin agent);
    }
}

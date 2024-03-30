using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IAgentRepository : IRepository<Agent>
    {
        Task<Agent?> Login(AgentLogin agent);
    }
}

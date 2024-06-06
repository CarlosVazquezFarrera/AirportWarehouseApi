using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.QueryFilter;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IAgentService
    {
        PagedResponse<AgentBaseInfo> GetPagedAgents(AgentParameters inventoryParameters);
        IEnumerable<Agent> GetAll();

        Task<Agent> Register(Agent agent);
    }
}

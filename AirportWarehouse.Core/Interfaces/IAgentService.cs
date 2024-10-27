using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.QueryFilter;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IAgentService : IEntityDtoService<Agent, AgentDTO>
    {
        PagedResponse<AgentBaseInfo> GetPagedAgents(AgentParameters agentParameters);
        IEnumerable<AgentDTO> GetAllAgentsWithoutAdmin();
        Task<AgentBaseInfo> Login(AgentLogin agent);
    }
}

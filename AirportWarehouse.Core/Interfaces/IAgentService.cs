using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.QueryFilter;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IAgentService : IEntityDtoService<Agent, AgentDetailInfo>
    {
        PagedResponse<AgentDetailInfo> GetPagedAgents(AgentParameters agentParameters);
        IEnumerable<AgentDetailInfo> GetAllAgentsWithoutAdmin();
        AgentDetailInfo Login(AgentLogin agent);
    }
}

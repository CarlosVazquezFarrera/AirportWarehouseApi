using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.QueryFilter;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IAgentService
    {
        PagedResponse<AgentBaseInfo> GetPagedAgents(AgentParameters agentParameters);
        PagedResponse<AgentBaseInfo> GetActiveAgentsPaged(BasePagedParameter agentParameters);
        PagedResponse<AgentBaseInfo> GetInactiveAgentsPaged(BasePagedParameter agentParameters);
        IEnumerable<AgentBaseInfo> GetAll();
        Task<AgentBaseInfo> Register(AgentDTO agentDTO);
        Task<AgentBaseInfo> Update(AgentDTO agent);
        Task<bool> SetPassword(AgentPasswordInfo agentPasswordInfo);
        Task<bool> DeactivateAgent(Guid IdAgent);
        Task<bool> ActivateAgent(Guid IdAgent);

    }
}

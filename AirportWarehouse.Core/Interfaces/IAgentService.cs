using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.QueryFilter;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IAgentService : IEntityDtoService<Agent, AgentDetailInfo>
    {
        PagedResponse<AgentBaseInfo> GetPagedAgents(AgentParameters agentParameters);
        IEnumerable<AgentBaseInfo> GetAllAgentsWithoutAdmin();
        Task<bool> SetPassword(AgentPasswordInfo agentPasswordInfo);
        Task<bool> DeactivateAgent(Guid IdAgent);
        Task<bool> ActivateAgent(Guid IdAgent);
        Task<AgentBaseInfo> Login(AgentLogin agent);
    }
}

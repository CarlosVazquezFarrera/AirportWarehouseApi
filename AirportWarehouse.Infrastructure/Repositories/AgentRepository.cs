using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public class AgentRepository : BaseRepositoty<Agent>, IAgentRepository
    {
        public AgentRepository(AirportwarehouseContext context) : base(context)
        {
        }

        public async Task<Agent?> Login(AgentLogin agent)
        {
            return await _entitie.Where(a => a.Password.Equals(agent.Password) && a.AgentNumber.Equals(agent.AgentNumber)).FirstOrDefaultAsync();
        }
    }
}

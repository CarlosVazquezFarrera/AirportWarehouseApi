using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        public AgentRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private readonly IUnitOfWork _unitOfWork;


        public async  Task<Agent?> Login(AgentLogin agent)
        {
            var adminpermition = await _unitOfWork.PermissionRepository.GetByCondition(p => p.Name.ToLower().Equals("admin"));

            return await _unitOfWork.AgentRepository
                .Include(a => a.AgentPermissions)
                .Where(
                    a => a.AgentNumber.Equals(agent.AgentNumber) 
                    && a.AgentPermissions.Any(p => p.PermissionId == adminpermition!.Id)
                    )
                .FirstOrDefaultAsync();

        }
    }
}

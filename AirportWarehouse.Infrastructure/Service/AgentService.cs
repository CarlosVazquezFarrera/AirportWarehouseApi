using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Helpers;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class AgentService(IUnitOfWork unitOfWork, IPagedListService<AgentBaseInfo> pagedListService, IMapper mapper) : IAgentService
    {
        public IEnumerable<AgentBaseInfo> GetAll()
        {
            var agents = unitOfWork.AgentRepository.GetAll().Where(agent => !agent.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase));
            return mapper.Map<IEnumerable<AgentBaseInfo>>(agents);
        }

        public PagedResponse<AgentBaseInfo> GetPagedAgents(AgentParameters agentParameters)
        {
            var agents = unitOfWork.AgentRepository.GetAll().Where(agent => !agent.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase));
            if (!String.IsNullOrEmpty(agentParameters.Search))
            {
                agents = agents.Where(a => a.Name.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase)
                || a.AgentNumber.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase));

            }
            var pagedResponse = pagedListService.Paginate(mapper.Map<IEnumerable<AgentBaseInfo>>(agents), agentParameters.PageNumber, agentParameters.PageSize);
            return pagedResponse;
        }

        public async Task<AgentBaseInfo> Register(AgentDTO agentDTO)
        {
            var agent = mapper.Map<Agent>(agentDTO);
            await unitOfWork.AgentRepository.Add(agent);
            await unitOfWork.SaveChanguesAsync();
            return mapper.Map<AgentBaseInfo>(agent);
        }

        public async Task<AgentBaseInfo> Update(AgentDTO agentDTO)
        {
            var agent = mapper.Map<Agent>(agentDTO);
            unitOfWork.AgentRepository.Update(agent);
            await unitOfWork.SaveChanguesAsync();
            return mapper.Map<AgentBaseInfo>(agent);
        }

        public async Task<bool> SetPassword(AgentPasswordInfo passwordInfo)
        {
            var agent = await unitOfWork.AgentRepository.GetById(passwordInfo.Id) ?? throw new NotFoundException();
            try
            {
    
                agent.Password = HashHelper.Hash(passwordInfo.Password);
                unitOfWork.AgentRepository.Update(agent);
                await unitOfWork.SaveChanguesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}

using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class AgentService(IUnitOfWork unitOfWork, 
        IPagedListService<AgentBaseInfo> _pagedListService, 
        IMapper _mapper,
        IPasswordService _passwordService) : IAgentService
    {
        public IEnumerable<AgentBaseInfo> GetAll()
        {
            var agents = GetAgentsWithoutAdmin();
            return _mapper.Map<IEnumerable<AgentBaseInfo>>(agents);
        }

        public PagedResponse<AgentBaseInfo> GetPagedAgents(AgentParameters agentParameters)
        {
            var agents = GetAgentsWithoutAdmin();
            if (!String.IsNullOrEmpty(agentParameters.Search))
            {
                agents = agents.Where(a => a.Name.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase)
                || a.AgentNumber.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase));

            }
            var pagedResponse = _pagedListService.Paginate(_mapper.Map<IEnumerable<AgentBaseInfo>>(agents), agentParameters.PageNumber, agentParameters.PageSize);
            return pagedResponse;
        }

        public async Task<AgentBaseInfo> Register(AgentDTO agentDTO)
        {
            var agent = _mapper.Map<Agent>(agentDTO);
            agent.IsActive = true;
            await unitOfWork.AgentRepository.Add(agent);
            await unitOfWork.SaveChanguesAsync();
            return _mapper.Map<AgentBaseInfo>(agent);
        }

        public async Task<AgentBaseInfo> Update(AgentDTO agentDTO)
        {
            Agent existingAgent = await unitOfWork.AgentRepository.GetById(agentDTO.Id) ?? throw new NotFoundException();
            _mapper.Map(agentDTO, existingAgent);
            unitOfWork.AgentRepository.Update(existingAgent);
            await unitOfWork.SaveChanguesAsync();
            return _mapper.Map<AgentBaseInfo>(existingAgent);
        }

        public async Task<bool> SetPassword(AgentPasswordInfo passwordInfo)
        {
            var agent = await unitOfWork.AgentRepository.GetById(passwordInfo.Id) ?? throw new NotFoundException();
            try
            {
    
                agent.Password = _passwordService.Hash(passwordInfo.Password);
                unitOfWork.AgentRepository.Update(agent);
                await unitOfWork.SaveChanguesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        private IEnumerable<Agent> GetAgentsWithoutAdmin()
        {
            return unitOfWork.AgentRepository.GetAll().Where(agent => !agent.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase));
        }
    }
}

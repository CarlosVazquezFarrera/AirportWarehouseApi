using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class AgentService : IAgentService
    {
        public AgentService(IUnitOfWork unitOfWork, IPagedListService<AgentBaseInfo> pagedListService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _pagedListService = pagedListService;
            _mapper = mapper;
        }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPagedListService<AgentBaseInfo> _pagedListService;
        public IEnumerable<Agent> GetAll()
        {
            return _unitOfWork.AgentRepository.GetAll().Where(agent => !agent.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase));
        }

        public PagedResponse<AgentBaseInfo> GetPagedAgents(AgentParameters agentParameters)
        {
            var agents = GetAll();
            if (!String.IsNullOrEmpty(agentParameters.Search))
            {
                agents = agents.Where(a => a.Name.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase)
                || a.AgentNumber.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase));

            }
            var pagedResponse = _pagedListService.Paginate(_mapper.Map<IEnumerable<AgentBaseInfo>>(agents), agentParameters.PageNumber, agentParameters.PageSize);
            return pagedResponse;
        }

        public async Task<Agent> Register(Agent agent)
        {
            await _unitOfWork.AgentRepository.Add(agent);
            await _unitOfWork.SaveChanguesAsync();
            return agent;

        }
    }
}

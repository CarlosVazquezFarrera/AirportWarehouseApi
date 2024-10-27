using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirportWarehouse.Infrastructure.Service
{
    public class AgentService : EntityDtoService<Agent, AgentDetailInfo>, IAgentService
    {
        public AgentService(IUnitOfWork unitOfWork, IMapper mapper, IPagedListService<AgentDetailInfo> pagedListService, IPasswordService passwordService) : base(mapper, unitOfWork, pagedListService)
        {
            _pagedListService = pagedListService;
            _passwordService = passwordService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IPagedListService<AgentDetailInfo> _pagedListService;
        private readonly IPasswordService _passwordService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IEnumerable<AgentDetailInfo> Agents
        {
            get { 
                return 
                   GetAll(); 
            }
        }

        public PagedResponse<AgentDetailInfo> GetPagedAgents(AgentParameters agentParameters)
        {
            var agents = GetAllAgentsWithoutAdmin();
            if (!String.IsNullOrEmpty(agentParameters.Search))
            {
                agents = agents.Where(a => a.Name.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase)
                || a.AgentNumber.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase));
            }
            var pagedResponse = _pagedListService.Paginate(agents, agentParameters.PageNumber, agentParameters.PageSize);
            return pagedResponse;
        }
        public IEnumerable<AgentDetailInfo> GetAllAgentsWithoutAdmin()
        {
            return Agents.Where(a => !a.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase));
        }

        public async Task<AgentDetailInfo> Login(AgentLogin agent)
        {
            Agent existingAgent = await _unitOfWork.Repository<Agent>().Include(a => a.AgentPermissions)
                .Where(
                    a =>
                    a.AgentNumber.Equals(agent.AgentNumber) &&
                    a.IsActive &&
                    a.AgentPermissions.Count != 0).FirstOrDefaultAsync() ?? throw new CredentialsException("Check your credentials");
            _passwordService.Check(existingAgent.Password, agent.Password);

            return _mapper.Map<AgentDetailInfo>(existingAgent);
        }
    }
}

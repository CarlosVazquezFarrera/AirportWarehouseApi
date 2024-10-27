using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirportWarehouse.Infrastructure.Service
{
    public class AgentService : EntityDtoService<Agent, AgentDTO>, IAgentService
    {
       
        private readonly IPagedListService<AgentBaseInfo> _pagedListService;
        private readonly IPasswordService _passwordService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgentService(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            IPagedListService<AgentBaseInfo> pagedListService, 
            IPasswordService passwordService) : base(mapper, unitOfWork)
        {
            _pagedListService = pagedListService;
            _passwordService = passwordService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public PagedResponse<AgentBaseInfo> GetPagedAgents(AgentParameters agentParameters)
        {
            var agents = GetAllAgentsWithoutAdmin();
            if (!String.IsNullOrEmpty(agentParameters.Search))
            {
                agents = agents.Where(a => a.Name.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase)
                || a.AgentNumber.Contains(agentParameters.Search, StringComparison.CurrentCultureIgnoreCase));
            }
            var pagedResponse = _pagedListService.Paginate(_mapper.Map<IEnumerable<AgentBaseInfo>>(agents), agentParameters.PageNumber, agentParameters.PageSize);
            return pagedResponse;
        }
        public IEnumerable<AgentDTO> GetAllAgentsWithoutAdmin()
        {
            return GetAll().Where(agent => !agent.Name.Equals("Administrador", StringComparison.OrdinalIgnoreCase));
        }

        public async Task<AgentBaseInfo> Login(AgentLogin agent)
        {
            Agent existingAgent = await _unitOfWork.Repository<Agent>().Include(a => a.AgentPermissions)
                .Where(
                    a =>
                    a.AgentNumber.Equals(agent.AgentNumber) &&
                    a.IsActive &&
                    a.AgentPermissions.Count != 0).FirstOrDefaultAsync() ?? throw new CredentialsException("Check your credentials");
            _passwordService.Check(existingAgent.Password, agent.Password);

            return _mapper.Map<AgentBaseInfo>(existingAgent);
        }
    }
}

using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AirportWarehouse.Infrastructure.Service
{
    public class LoginService : ILoginService
    {
        public LoginService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public async Task<AgentDTO> Login(AgentLogin agent)
        {
            var existingAgent = await _unitOfWork.AgentRepository
                .Include(a => a.AgentPermissions)
                .Where(
                    a => 
                    a.AgentNumber.Equals(agent.AgentNumber) && 
                    a.IsActive &&
                    a.AgentPermissions.Count != 0)
                .FirstOrDefaultAsync() ?? throw new CredentialsException("Check your credentials");
            
            return _mapper.Map<AgentDTO>(existingAgent);
        }
    }
}

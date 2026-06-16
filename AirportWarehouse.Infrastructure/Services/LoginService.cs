using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Request;
using AirportWarehouse.Infrastructure.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using AirportWarehouse.Utils.Helpers.Password;
using AirportWarehouse.Utils.Mapper;

namespace AirportWarehouse.Infrastructure.Services;

public class LoginService: ILoginService
{
    public LoginService(IUnitOfWork unitOfWork, IGenericMapper<Agent, AgentDto> mapper, IPassWordHelper passWordHelper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _passWordHelper = passWordHelper;
    }
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGenericMapper<Agent, AgentDto> _mapper;
    private readonly IPassWordHelper _passWordHelper;
    public async Task<AgentDto?> Login(LoginRequest user)
    {
        var existingAgent = await _unitOfWork.Repository<Agent>()
            .GetByConditionAsync(a => a.AgentNumber.Equals(user.AgentNumber) && a.IsActive)
            .ConfigureAwait(false);
        
        if (existingAgent is null) 
            return null;

        _passWordHelper.Check(existingAgent.Password, user.Password);

        return _mapper.ToDto(existingAgent);
    }
}

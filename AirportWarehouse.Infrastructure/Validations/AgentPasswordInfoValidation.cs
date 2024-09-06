using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class AgentPasswordInfoValidation : AbstractValidator<AgentPasswordInfo>
    {
        public AgentPasswordInfoValidation()
        {
            RuleFor(agentInfo => agentInfo.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(agentInfo => agentInfo.Password)
                .NotEmpty()
                .MinimumLength(5)
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$^&*()_-]).*$")
                .Matches("");
        }
    }
}

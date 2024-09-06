using AirportWarehouse.Core.DTOs;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class AgentValidation : AbstractValidator<AgentDTO>
    {
        public AgentValidation()
        {
            RuleFor(airpot => airpot.AgentNumber)
               .NotNull()
               .NotEmpty();

            RuleFor(airpot => airpot.ShortName)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2);

            RuleFor(airpot => airpot.Name)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2);

            RuleFor(airpot => airpot.LastName)
              .NotNull()
              .NotEmpty()
              .MinimumLength(2);

            RuleFor(airpot => airpot.Email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .EmailAddress();
        }
    }
}

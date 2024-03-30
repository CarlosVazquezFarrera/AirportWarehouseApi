using AirportWarehouse.Core.DTOs;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class AirportValidator: AbstractValidator<AirportDTO>
    {
        public AirportValidator()
        {
            RuleFor(airpot => airpot.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}

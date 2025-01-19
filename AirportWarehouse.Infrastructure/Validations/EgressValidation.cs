using AirportWarehouse.Core.DTOs;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class EgressValidation : AbstractValidator<EgressDTO>
    {
        public EgressValidation()
        {
            RuleFor(egress => egress.AmountRemoved)
                .GreaterThan(0);
        }
    }
}

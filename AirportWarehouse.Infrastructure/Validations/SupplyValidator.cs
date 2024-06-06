using AirportWarehouse.Core.DTOs;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class SupplyValidator : AbstractValidator<SupplyDTO>
    {
        public SupplyValidator()
        {
            RuleFor(entry => entry.AirportId).NotNull().NotEmpty();
            RuleFor(entry => entry.ProductId).NotNull().NotEmpty();
            RuleFor(entry => entry.CurrentQuantity).GreaterThan(0);
        }
    }
}

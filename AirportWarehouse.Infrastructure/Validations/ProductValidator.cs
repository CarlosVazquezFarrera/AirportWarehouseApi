using AirportWarehouse.Core.Entites;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(entry => entry.PresentationQuantity).GreaterThan(0);
            RuleFor(entry => entry.FormatQuantity).GreaterThan(0);
        }
    }
}

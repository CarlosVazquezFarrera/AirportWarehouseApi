using AirportWarehouse.Core.DTOs;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class ProductValidation : AbstractValidator<ProductDTO>
    {
        public ProductValidation()
        {
            RuleFor(entry => entry.Name).NotEmpty();
            RuleFor(entry => entry.SupplierPart).NotEmpty();
        }
    }
}

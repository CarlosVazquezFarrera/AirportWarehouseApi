using AirportWarehouse.Core.DTOs;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class EntryValidator : AbstractValidator<EntryDTO>
    {
        public EntryValidator()
        {
            RuleFor(entry => entry.QuantityIncoming).GreaterThan(0);
        }
    }
}

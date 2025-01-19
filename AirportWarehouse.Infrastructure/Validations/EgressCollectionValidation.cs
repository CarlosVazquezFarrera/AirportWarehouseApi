using AirportWarehouse.Core.DTOs;
using FluentValidation;

namespace AirportWarehouse.Infrastructure.Validations
{
    public class EgressCollectionValidation : AbstractValidator<IEnumerable<EgressDTO>>
    {
        public EgressCollectionValidation()
        {
            RuleForEach(egress => egress)
                .SetValidator(new EgressValidation());
        }
    }
}

using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using AirportWarehouse.Utils.Helpers.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AirportWarehouse.Controllers
{
    public class ProductController : GenericController<Product, ProductDto>
    {
        [FromQuery] public Guid? CategoryId { get; set; }
        [FromQuery] public Guid? ProductFormatId { get; set; }
        [FromQuery] public Guid? PackagingTypeId { get; set; }
        [FromQuery] public string? Search { get; set; }

        public ProductController(IClaimHelper claimHelper, IProductService service): base(service) 
        {
            _claimHelper = claimHelper;
        }

        private IClaimHelper _claimHelper;

        protected override Expression<Func<ProductDto, bool>>? BuildFilter()
        {
            Guid AirportId = _claimHelper.GetAirportId();

            if (AirportId.Equals(Guid.Empty) && !CategoryId.HasValue && !ProductFormatId.HasValue && !PackagingTypeId.HasValue && Search is null)
                return null;

            return p => p.AirportId == AirportId
                && (!CategoryId.HasValue || p.CategoryId == CategoryId)
                && (!ProductFormatId.HasValue || p.ProductFormatId == ProductFormatId)
                && (!PackagingTypeId.HasValue || p.PackagingTypeId == PackagingTypeId)
                && (Search == null
                    || p.Name.ToLower().Contains(Search.ToLower())
                    || p.SupplierPart.ToLower().Contains(Search.ToLower()));
        }
        protected override IEnumerable<Expression<Func<Product, object>>>? BuildIncludes() 
            => [
                p => p.Category,
                p => p.ProductFormat,
                p => p.Presentation,
                p => p.PackagingType
                ];
    }
}

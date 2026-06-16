using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Utils.Helpers.Claims;
using AirportWarehouseAdminApi.Utils.Mapper;

namespace AirportWarehouse.Utils.Mapper.Profiles
{
    public class ProductMappingProfile : MappingProfile<Product, ProductDto>
    {
        public ProductMappingProfile(IClaimHelper claimHelper)
        {
            Map(dto => dto.ProductFormatName, entity => entity.ProductFormat.Name);
            Map(dto => dto.CategoryName, entity => entity.Category.Name);
            Map(dto => dto.PackagingTypeName, entity => entity.PackagingType.Name);
            Map(dto => dto.PresentationName, entity => entity.Presentation.Name);

            MapToEntity(entity => entity.AirportId, dto => claimHelper.GetAirportId());
            
            MapUpdate((entity, dto) =>
            {
                entity.Name = dto.Name;
                entity.ProductFormatId = dto.ProductFormatId;
                entity.CategoryId = dto.CategoryId;
                entity.PackagingTypeId = dto.PackagingTypeId;
                entity.FormatQuantity = dto.FormatQuantity;
                entity.PresentationQuantity = dto.PresentationQuantity;
                entity.FormatQuantity = dto.FormatQuantity;
                entity.Stock = dto.Stock;
                entity.AirportId = claimHelper.GetAirportId();
            });
        }
    }
}

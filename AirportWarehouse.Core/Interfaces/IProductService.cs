using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.QueryFilter;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IProductService : IEntityDtoService<Product, ProductDTO>
    {
        PagedResponse<ProductDTO> GetProdcutsByAirport(ProductsFilter parameters);
        Task<SupplyMovement> IncreaseProduct(Guid IdProduct, int QuantityReceived);
        Task<SupplyMovement> DecreaseProduct(Guid IdProduct, int WithdrawalAmount);
    }
}

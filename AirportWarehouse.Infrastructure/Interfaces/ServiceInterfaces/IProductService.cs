using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

public interface IProductService : IGenericService<Product, ProductDto>
{
    Task<(int QuantityBefore, int QuantityAfter)> DecreaseProduct(Guid ProductId, int WithdrawalAmount);
    Task<(int QuantityBefore, int QuantityAfter)> IncreaseProduct(Guid ProductId, int QuantityIncoming);
}

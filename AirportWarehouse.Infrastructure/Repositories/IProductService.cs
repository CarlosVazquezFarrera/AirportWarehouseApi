using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public interface IProductService : IEntityDtoService<Product, ProductDTO>
    {
        IEnumerable<ProductDTO> GetProductsMissingInAirport(Guid idAirport);
    }
}

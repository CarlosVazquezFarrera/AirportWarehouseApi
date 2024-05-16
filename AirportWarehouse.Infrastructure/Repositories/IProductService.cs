using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsMissingInAirport(Guid idAirport);
        IEnumerable<Product> GetAll();
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
    }
}

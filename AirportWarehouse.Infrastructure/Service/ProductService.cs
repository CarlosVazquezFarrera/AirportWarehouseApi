using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Repositories;

namespace AirportWarehouse.Infrastructure.Service
{
    public class ProductService : IProductService
    {
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Product> GetProductsMissingInAirport(Guid idAirport)
        {
            var products = _unitOfWork.ProductRepository.GetAll();
            var supplies = _unitOfWork.SupplyRepository.GetAll();
            var result = (from p in products
                          join s in supplies.Where(s => s.AirportId == idAirport)
                          on p.Id equals s.ProductId into ps
                          from sub in ps.DefaultIfEmpty()
                          where sub == null
                          select p).ToList();
            return result;
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChanguesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChanguesAsync();
            return product;
        }
    }
}

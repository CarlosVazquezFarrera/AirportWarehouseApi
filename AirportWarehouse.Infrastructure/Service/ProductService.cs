using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Repositories;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class ProductService : EntityDtoService<Product, ProductDTO>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetProductsMissingInAirport(Guid idAirport)
        {
            var products = _unitOfWork.Repository<Product>().GetAll().AsQueryable();
            var supplies = _unitOfWork.Repository<Supply>().GetAll().AsQueryable();
            var result = (from p in products
                          join s in supplies.Where(s => s.AirportId == idAirport)
                          on p.Id equals s.ProductId into ps
                          from sub in ps.DefaultIfEmpty()
                          where sub == null
                          select p).ToList();
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }
    }
}

using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AirportWarehouse.Infrastructure.Service
{
    public class ProductService : EntityDtoService<Product, ProductDTO>, IProductService
    {
        private readonly IClaimService _claimService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQueryService<ProductDTO> _queryService;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IClaimService claimService, IPagedListService<ProductDTO> pagedListService, IQueryService<ProductDTO> queryService) : base(mapper, unitOfWork, pagedListService)
        {
            _claimService = claimService;
            _queryService = queryService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public override Task<ProductDTO> AddAsync(ProductDTO ProductDTO)
        {
            ProductDTO.AirportId = _claimService.GetAirpotId();
            ProductDTO.Stock = ProductDTO.FormatQuantity * ProductDTO.PresentationQuantity;
            return base.AddAsync(ProductDTO);
        }


        public PagedResponse<ProductDTO> GetProdcutsByAirport(ProductsFilter parameters)
        {
            Guid airportId = parameters.AirportId == Guid.Empty ? _claimService.GetAirpotId() : parameters.AirportId;
            var filters = new List<Expression<Func<ProductDTO, bool>>>()
            {
                p => p.AirportId.Equals(airportId),
            };

            if (!String.IsNullOrEmpty(parameters.Search))
            {
                filters.Add(
                    p=> p.Name.Contains(parameters.Search, StringComparison.CurrentCultureIgnoreCase) ||
                p.SupplierPart!.Contains(parameters.Search, StringComparison.CurrentCultureIgnoreCase));
            }

            IEnumerable<Product> products = _unitOfWork.Repository<Product>()
                .Include(p => p.PackagingType)
                .Include(p => p.ProductFormat)
                .Include(p => p.Presentation);
            return _queryService.FilterAndPaginate(_mapper.Map<IEnumerable<ProductDTO>>(products), filters, parameters.PageNumber,parameters.PageSize);
        }
    }
}

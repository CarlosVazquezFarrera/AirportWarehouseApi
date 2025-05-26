using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Core.QueryFilter;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;
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
        public override Task<ProductDTO> AddAsync(ProductDTO productDTO)
        {
            productDTO.AirportId = _claimService.GetAirportId();
            productDTO.Stock = productDTO.FormatQuantity * productDTO.PresentationQuantity;
            return base.AddAsync(productDTO);
        }
        public override Task<ProductDTO> UpdateAsync(ProductDTO productDTO)
        {
            productDTO.AirportId = _claimService.GetAirportId();
            return base.UpdateAsync(productDTO);
        }

        public async Task<SupplyMovement> DecreaseProduct(Guid IdProduct, int WithdrawalAmount)
        {
            ProductDTO productDTO = await GetByIdAsync(IdProduct);

            if (WithdrawalAmount > productDTO.Stock)
                throw new BusinessException("Insufficient stock");

            int QuantityAfter = productDTO.Stock - WithdrawalAmount;

            SupplyMovement supplyMovement = new()
            {
                QuantityBefore = productDTO.Stock,
                QuantityAfter = QuantityAfter
            };
            productDTO.Stock = QuantityAfter;
            await UpdateAsync(productDTO);
            return supplyMovement;

        }

        public PagedResponse<ProductDTO> GetProdcutsByAirport(ProductsFilter parameters)
        {
            Guid airportId = parameters.AirportId == Guid.Empty ? _claimService.GetAirportId() : parameters.AirportId;
            var filters = new List<Expression<Func<Product, bool>>>()
            {
                p => p.AirportId.Equals(airportId),
            };

            if (!string.IsNullOrEmpty(parameters.Search))
            {
                string searchLower = parameters.Search.ToLower();

                filters.Add(
                    p => p.Name.ToLower().Contains(searchLower) ||
                    p.SupplierPart!.ToLower().Contains(searchLower));
            }

            if (parameters.CategoryId != Guid.Empty)
            {
                filters.Add(p => p.CategoryId.Equals(parameters.CategoryId));
            }
            if (parameters.ProductFormatId != Guid.Empty)
            {
                filters.Add(p => p.ProductFormatId.Equals(parameters.ProductFormatId));
            }


            return GetPagedWithSearch(parameters.PageNumber, parameters.PageSize, filters, 
                p => p.PackagingType, p => p.ProductFormat, p => p.Presentation, p => p.Category);

        }

        public async Task<SupplyMovement> IncreaseProduct(Guid IdProduct, int QuantityReceived)
        {
            ProductDTO productDTO = await GetByIdAsync(IdProduct);
            int TotalUnitsReceived = productDTO.PresentationQuantity * productDTO.FormatQuantity;
            int QuantityAfter = productDTO.Stock +  (TotalUnitsReceived * QuantityReceived);

            SupplyMovement supplyMovement = new()
            {
                QuantityBefore = productDTO.Stock,
                QuantityAfter = QuantityAfter
            };
            productDTO.Stock = QuantityAfter;
            await UpdateAsync(productDTO);
            return supplyMovement;
        }
    }
}

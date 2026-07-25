using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.ParamerEntities;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using AirportWarehouse.Utils.Helpers.Claims;
using AirportWarehouse.Utils.Helpers.Extension;
using AirportWarehouse.Utils.Mapper;
using AirportWarehouseAdminApi.Core.CustomEntities;

namespace AirportWarehouse.Infrastructure.Services
{
    public class EgressService : GenericService<Egress, EgressDto>, IEgressService
    {
        public EgressService(IUnitOfWork unitOfWork, IGenericMapper<Egress, EgressDto> mapper, IProductService productService, IClaimHelper claimHelper) : base(unitOfWork, mapper)
        {
            _uow = unitOfWork;
            _productService = productService;
            _mapper = mapper;
            _claimHelper = claimHelper;
        }
        private readonly IUnitOfWork _uow;
        private readonly IProductService _productService;
        private readonly IGenericMapper<Egress, EgressDto> _mapper;
        private readonly IClaimHelper _claimHelper;

        public override async Task<IEnumerable<EgressDto>> CreateListAsync(IEnumerable<EgressDto> egresses)
        {

            if (egresses.Any(e => e.AmountRemoved <= 0)) 
                throw new BusinessException("AmountRemoved cannot be smaller than 1");

            List<Egress> processedEgresses = [];

            await _uow.ExecuteTransaction(async() =>
            {
                foreach (var egress in egresses)
                {
                    var (QuantityBefore, QuantityAfter) = await _productService.DecreaseProduct(egress.ProductId, egress.AmountRemoved);
                    egress.QuantityBefore = QuantityBefore;
                    egress.QuantityAfter = QuantityAfter;
                    var newEgress = await _uow.Repository<Egress>().CreateAsync(_mapper.ToEntity(egress));
                    processedEgresses.Add(newEgress);
                }
            });
            return _mapper.ToDtoList(processedEgresses);
        }

        public async Task<PagedResult<LedgerEgressMovement>> CountUnitRemoved(PaginationsParams paginations, DateOnly? date)
        {            
            var query = _uow.Repository<Egress>().Query();

            var (start, end) = date.FirstAndLastDate();
            query = query.Where(e => _claimHelper.GetAirportId().Equals(e.AirportId) && e.Date >= start && e.Date <= end);

            var data = query
                .GroupBy(e => new
                {
                    e.Product.Id,
                    e.Product.Name,
                    e.Product.SupplierPart
                })
                .Select(g => new LedgerEgressMovement()
                {
                    Id = g.Key.Id,
                    Name = g.Key.Name,
                    SupplierPart = g.Key.SupplierPart,
                    UnitsRemoved = g.Sum(x => x.AmountRemoved),
                    TotalMovements = g.Count()
                })
                .OrderByDescending(e => e.UnitsRemoved);

            return await data.ToPagedResultASync(paginations.Page, paginations.PageSize);

        }
    }
}

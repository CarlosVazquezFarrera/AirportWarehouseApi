using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using AirportWarehouse.Utils.Mapper;

namespace AirportWarehouse.Infrastructure.Services
{
    public class EgressService : GenericService<Egress, EgressDto>
    {
        public EgressService(IUnitOfWork unitOfWork, IGenericMapper<Egress, EgressDto> mapper, IProductService productService) : base(unitOfWork, mapper)
        {
            _uow = unitOfWork;
            _productService = productService;
            _mapper = mapper;
        }
        private readonly IUnitOfWork _uow;
        private readonly IProductService _productService;
        private readonly IGenericMapper<Egress, EgressDto> _mapper;

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
    
    }
}

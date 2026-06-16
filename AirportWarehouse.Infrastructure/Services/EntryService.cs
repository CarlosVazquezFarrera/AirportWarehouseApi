using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using AirportWarehouse.Utils.Mapper;

namespace AirportWarehouse.Infrastructure.Services
{
    public class EntryService : GenericService<Entry, EntryDto>
    {
        public EntryService(IGenericMapper<Entry, EntryDto>  mapper, IUnitOfWork uow, IProductService productService) : base(uow, mapper)
        {
            _uow = uow;
            _productService = productService;
            _mapper = mapper;
        }

        private readonly IUnitOfWork _uow;
        private readonly IProductService _productService;
        private readonly IGenericMapper<Entry, EntryDto> _mapper;


        public async override Task<EntryDto> CreateAsync(EntryDto dto)
        {
            Entry newEntry = new();
            await _uow.ExecuteTransaction(async ()=>
            {
                var (QuantityBefore, QuantityAfter) = await _productService.IncreaseProduct(dto.ProductId!.Value, dto.QuantityIncoming).ConfigureAwait(false);
                dto.QuantityAfter = QuantityAfter;
                dto.QuantityBefore = QuantityBefore;
                newEntry = await _uow.Repository<Entry>().CreateAsync(_mapper.ToEntity(dto));
                await _uow.SaveChangesAsync();
            });

            return _mapper.ToDto(newEntry);
        }
    }
}

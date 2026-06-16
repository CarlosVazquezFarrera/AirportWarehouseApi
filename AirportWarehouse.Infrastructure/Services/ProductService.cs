using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;
using AirportWarehouse.Utils.Mapper;

namespace AirportWarehouse.Infrastructure.Services
{
    public class ProductService : GenericService<Product, ProductDto>, IProductService
    {
        public ProductService(IUnitOfWork uow, IGenericMapper<Product, ProductDto> mapper) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        IUnitOfWork _uow;
        IGenericMapper<Product, ProductDto> _mapper;

        public async Task<(int QuantityBefore, int QuantityAfter)> DecreaseProduct(Guid ProductId, int WithdrawalAmount)
        {
            ProductDto? productDto = await GetByIdAsync(ProductId) ?? throw new NotFoundException($"Product {ProductId}");

            if (WithdrawalAmount > productDto.Stock)
                throw new BusinessException("Insufficient stock");
            
            int QuantityBefore = productDto.Stock;
            int QuantityAfter = productDto.Stock - WithdrawalAmount;

            productDto.Stock = QuantityAfter;
            await _uow.Repository<Product>().UpdateAsync(_mapper.ToEntity(productDto));
            return (QuantityBefore, QuantityAfter);
        }

        public async Task<(int QuantityBefore, int QuantityAfter)> IncreaseProduct(Guid ProductId, int QuantityIncoming)
        {
            ProductDto? productDto = await GetByIdAsync(ProductId) ?? throw new NotFoundException($"Product {ProductId}");
            int TotalUnitsReceived = productDto.PresentationQuantity * productDto.FormatQuantity;
            int QuantityAfter = productDto.Stock +  (TotalUnitsReceived * QuantityIncoming);
            
            int QuantityBefore = productDto.Stock;
            productDto.Stock = QuantityAfter;
            await _uow.Repository<Product>().UpdateAsync(_mapper.ToEntity(productDto));
            return (QuantityBefore, QuantityAfter);
        }

        public override async Task<ProductDto?> UpdateAsync(ProductDto dto)
        {
            var existing = await _uow.Repository<Product>().GetByIdAsync(dto.Id);
            if (existing is null) return null;
            dto.Stock = existing.Stock;
            _mapper.ApplyUpdate(existing, dto);

            var updated = await _uow.Repository<Product>().UpdateAsync(existing);

            if (updated is null) return null;

            await _uow.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.ToDto(updated);
        }
    }
}

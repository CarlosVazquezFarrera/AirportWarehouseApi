using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class EntryService : EntityDtoService<Entry, EntryDTO>, IEntityDtoService<Entry, EntryDTO>
    {
        public EntryService(IMapper mapper, IUnitOfWork unitOfWork, IClaimService claimService, IPagedListService<EntryDTO> pagedListService, IProductService productService)  : base(mapper, unitOfWork, pagedListService)
        {
            _unitOfWork = unitOfWork;
            _userId = claimService.GetUserId();
            _productService = productService;
        }
        private readonly IUnitOfWork _unitOfWork;
        private readonly Guid _userId;
        private readonly IProductService _productService;
        public async override Task<EntryDTO> AddAsync(EntryDTO entry)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                SupplyMovement movement = await _productService.IncreaseProduct(entry.ProductId, entry.QuantityIncoming);
                entry.AgentId = _userId;
                entry.QuantityAfter = movement.QuantityAfter;
                entry.QuantityBefore = movement.QuantityBefore;
                EntryDTO entryDTO = await base.AddAsync(entry);
                await _unitOfWork.CommitTransactionAsync();
                return entryDTO;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}

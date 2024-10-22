using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class EntryService : EntityDtoService<Entry, EntryDTO>, IEntryService
    {

        public EntryService(IMapper mapper, IUnitOfWork unitOfWork, IClaimService claimService, ISupplyService supplyService)  : base(mapper, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userId = claimService.GetUserId();
            _supplyService = supplyService;
        }
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplyService _supplyService;
        private readonly Guid _userId;
        public async override Task<EntryDTO> AddAsync(EntryDTO entry)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                SupplyMovement movement = await _supplyService.IncreaseSupply(entry.SupplyId, entry.QuantityIncoming);
                entry.SupplyId = _userId;
                entry.QuantityBefore = movement.QuantityBefore;
                entry.QuantityAfter = movement.QuantityAfter;
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

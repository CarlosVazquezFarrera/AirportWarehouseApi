using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;

namespace AirportWarehouse.Infrastructure.Service
{
    public class EntryService : IEntryService
    {
        public EntryService(IUnitOfWork unitOfWork, IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _claimService = claimService;   

        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimService _claimService;
        public async Task<Entry> Create(Entry entry)
        {

            var supply = await _unitOfWork.SupplyRepository.GetById(entry.SupplyId);
            if (supply == null)
                throw new BusinessException("Supply was not found");
            entry.AgentId = _claimService.GetUserId();
            int newQuantity = supply.CurrentQuantity + entry.QuantityIncoming;
            entry.QuantityBefore = supply.CurrentQuantity;
            entry.QuantityAfter = newQuantity;

            supply.CurrentQuantity = newQuantity;
            entry.Supply = supply;

            await _unitOfWork.EntryRepository.Add(entry);
            await _unitOfWork.SaveChanguesAsync();
            return entry;


        }
    }
}

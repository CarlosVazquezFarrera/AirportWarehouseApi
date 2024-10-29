using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class EgressService : EntityDtoService<Egress, EgressDTO>,  IEntityDtoService<Egress, EgressDTO>
    {
        public EgressService(IMapper mapper, IUnitOfWork unitOfWork, ISupplyService supplyService, IClaimService claimService, IPagedListService<EgressDTO> pagedListService) : base(mapper, unitOfWork, pagedListService)
        {
            _unitOfWork = unitOfWork;
            _supplyService = supplyService;
            _userId = claimService.GetUserId();
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplyService _supplyService;
        private readonly Guid _userId;

        public async override Task<EgressDTO> AddAsync(EgressDTO egress)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                SupplyMovement movement = await _supplyService.DecreaseSupply(egress.SupplyId, egress.AmountRemoved);
                egress.ApproverId = _userId;
                egress.QuantityBefore = movement.QuantityBefore;
                egress.QuantityAfter = movement.QuantityAfter;
                EgressDTO egressDTO = await base.AddAsync(egress);
                await _unitOfWork.SaveChanguesAsync();
                return egressDTO;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
         
        }
    }
}

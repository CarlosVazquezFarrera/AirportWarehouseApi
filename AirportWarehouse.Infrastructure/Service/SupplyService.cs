using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class SupplyService : EntityDtoService<Supply, SupplyDTO>, ISupplyService
    {
        public SupplyService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<SupplyMovement> DecreaseSupply(Guid IdSupply, int WithdrawalAmount)
        {
            SupplyDTO supply = await GetByIdAsync(IdSupply);
            
            if (WithdrawalAmount > supply.CurrentQuantity)
                throw new BusinessException("Insufficient stock");

            int QuantityAfter = supply.CurrentQuantity - WithdrawalAmount;

            SupplyMovement supplyMovement = new SupplyMovement();
            supplyMovement.QuantityBefore = supply.CurrentQuantity;
            supplyMovement.QuantityAfter = QuantityAfter;
            supply.CurrentQuantity = QuantityAfter;
            await UpdateAsync(supply);
            return supplyMovement;
        }

        public async Task<SupplyMovement> IncreaseSupply(Guid IdSupply, int QuantityReceived)
        {
            SupplyDTO supply = await GetByIdAsync(IdSupply);

            int QuantityAfter = supply.CurrentQuantity + QuantityReceived;

            SupplyMovement supplyMovement = new SupplyMovement();
            supplyMovement.QuantityBefore = supply.CurrentQuantity;
            supplyMovement.QuantityAfter = QuantityAfter;
            supply.CurrentQuantity = QuantityAfter;
            await UpdateAsync(supply);
            return supplyMovement;
        }
    }
}

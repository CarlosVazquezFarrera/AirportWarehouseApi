using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface ISupplyService : IEntityDtoService<Supply, SupplyDTO>
    {
        Task<SupplyMovement> IncreaseSupply(Guid IdSupply, int QuantityReceived);
        Task<SupplyMovement> DecreaseSupply(Guid IdSupply, int WithdrawalAmount);
    }
}

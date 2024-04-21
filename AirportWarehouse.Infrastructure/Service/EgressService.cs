using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;

namespace AirportWarehouse.Infrastructure.Service
{
    public class EgressService : IEgressService
    {
        public EgressService(IUnitOfWork unitOfWork,IClaimService claimService)
        {
            IdUser = claimService.GetUserId();
            _unitOfWork = unitOfWork;

        }
        private readonly IUnitOfWork _unitOfWork;
        private readonly Guid IdUser;


        public async Task<Egress> Create(Egress egress)
        {
            var supply = await _unitOfWork.SupplyRepository.GetById(egress.SupplyId)!;
            if (egress.AmountRemoved <= 0)
            {
                throw new BusinessException("Must be at least 1 item");
            }

            if (egress.AmountRemoved > supply.CurrentQuantity)
            {
                throw new BusinessException("Insufficient stock");
            }
            egress.QuantityBefore = supply.CurrentQuantity;
            int newQuantity = supply.CurrentQuantity - egress.AmountRemoved;
            egress.QuantityAfter = newQuantity;
            egress.ApproverId = IdUser;
            supply.CurrentQuantity = newQuantity;
            egress.ApproverNavigation = supply;

            await _unitOfWork.EgressRepository.Add(egress);
            await _unitOfWork.SaveChanguesAsync();
            return egress;
        }
    }
}

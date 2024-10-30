using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class EgressService : EntityDtoService<Egress, EgressDTO>, IEntityDtoService<Egress, EgressDTO>
    {
        public EgressService(IMapper mapper, IUnitOfWork unitOfWork, IPagedListService<EgressDTO> pagedListService, IProductService productService, IClaimService claimService) : base(mapper, unitOfWork, pagedListService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            agentId = claimService.GetUserId();
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly Guid agentId;
        public async override Task<EgressDTO> AddAsync(EgressDTO egress)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                SupplyMovement movement = await _productService.DecreaseProduct(egress.ProductId, egress.AmountRemoved);
                egress.QuantityBefore = movement.QuantityBefore;
                egress.ApproverId = agentId;
                egress.QuantityAfter = movement.QuantityAfter;
                EgressDTO entryDTO = await base.AddAsync(egress);
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

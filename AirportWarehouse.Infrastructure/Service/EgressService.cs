using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Exceptions;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;

namespace AirportWarehouse.Infrastructure.Service
{
    public class EgressService : EntityDtoService<Egress, EgressDTO>, IEgressService
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

        public async Task<IEnumerable<EgressDTO>> CreateEgressOrder(IEnumerable<EgressDTO> egresses)
        {

            if (egresses.Any(e => e.AmountRemoved <= 0)) throw new BusinessException("AmountRemoved cannot be smaller than 1");

            try
            {
                var processedEgresses = new List<EgressDTO>();
                await _unitOfWork.BeginTransactionAsync();
                foreach (var egress in egresses)
                {
                    SupplyMovement movement = await _productService.DecreaseProduct(egress.ProductId, egress.AmountRemoved);
                    egress.QuantityBefore = movement.QuantityBefore;
                    egress.ApproverId = agentId;
                    egress.QuantityAfter = movement.QuantityAfter;
                    EgressDTO entryDTO = await base.AddAsync(egress);
                    processedEgresses.Add(entryDTO);
                }
                await _unitOfWork.CommitTransactionAsync();
                return processedEgresses;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw new BusinessException();
            }
        }
    
    }
}

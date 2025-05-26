using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Entites;
using System.Linq.Expressions;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IEntityDtoService<TEntity, TDto>where TEntity : BaseEntity
    {
        IEnumerable<TDto> GetAll();
        PagedResponse<TDto> GetPaged(int? pageNumber, int? pageSize);
        Task<TDto> GetByIdAsync(Guid Id);
        Task<TDto> AddAsync(TDto DtoEntity);
        Task<TDto> UpdateAsync(TDto DtoEntity);
        PagedResponse<TDto> GetPagedWithSearch(int? pageNumber, int? pageSize, List<Expression<Func<TEntity, bool>>> filters, params Expression<Func<TEntity, object>>[] includes);

    }
}

using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.ParamerEntities;
using AirportWarehouseAdminApi.Core.CustomEntities;
using System.Linq.Expressions;

namespace AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

public interface IGenericService<TEntity, TDto> where TDto : BaseDto where TEntity : BaseEntity
{
    Task<IEnumerable<TDto>> GetAllAsync(IEnumerable<Expression<Func<TEntity, object>>>? includes = null);
    Task<TDto?> GetByIdAsync(Guid Id);
    Task<TDto> CreateAsync(TDto dto);
    Task<IEnumerable<TDto>> CreateListAsync(IEnumerable<TDto> dtos);
    Task<TDto?> UpdateAsync(TDto dto);
    Task<bool> DeleteAsync(Guid Id);

    Task<PagedResult<TDto>> GetPagedAsync(
        PaginationsParams paginations,
        Expression<Func<TDto, bool>>? filter = null,
        IEnumerable<Expression<Func<TEntity, object>>>? includes = null);
}

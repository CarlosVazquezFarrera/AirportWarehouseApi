using AirportWarehouse.Core.Entites;
using System.Linq.Expressions;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IEntityDtoService<TEntity, TDto>where TEntity : BaseEntity
    {
        IEnumerable<TDto> GetAll();
        Task<TDto> GetByIdAsync(Guid Id);
        Task<TDto> AddAsync(TDto DtoEntity);
        Task<TDto> UpdateAsync(TDto DtoEntity);

    }
}

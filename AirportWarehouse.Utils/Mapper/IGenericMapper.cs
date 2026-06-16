using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using System.Linq.Expressions;

namespace AirportWarehouse.Utils.Mapper;

public interface IGenericMapper<TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
{
    TDto ToDto(TEntity entity);
    TEntity ToEntity(TDto dto);

    void ApplyUpdate(TEntity entity, TDto dto);

    IEnumerable<TDto> ToDtoList(IEnumerable<TEntity> entities);
    Expression<Func<TEntity, bool>> ToEntityExpression(Expression<Func<TDto, bool>> expr);
}

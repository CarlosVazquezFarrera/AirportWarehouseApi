using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using System.Linq.Expressions;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IQueryService<TDto> where TDto : BaseDTO
    {
        PagedResponse<TDto> FilterAndPaginate(
            IEnumerable<TDto> list,
            List<Expression<Func<TDto, bool>>> filters,
            int? pageNumber,
            int? pageSize);
    }

}

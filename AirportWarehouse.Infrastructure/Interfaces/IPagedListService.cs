using AirportWarehouse.Core.CustomEntities;

namespace AirportWarehouse.Infrastructure.Interfaces
{
    public interface IPagedListService<T>
    {
        PagedResponse<T> Paginate(IEnumerable<T> data, int? pageNumber, int? pageSize);
    }
}

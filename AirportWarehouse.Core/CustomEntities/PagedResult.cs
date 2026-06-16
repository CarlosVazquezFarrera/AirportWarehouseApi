
using AirportWarehouse.Core.Dtos;

namespace AirportWarehouseAdminApi.Core.CustomEntities;

public class PagedResult<TDto> where TDto : BaseDto
{
    public IEnumerable<TDto> Data { get; init; } = [];
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => Page < TotalPages;
}

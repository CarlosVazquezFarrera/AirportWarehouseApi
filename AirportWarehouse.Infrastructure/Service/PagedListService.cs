using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Options;
using AirportWarehouse.Infrastructure.Interfaces;
using Microsoft.Extensions.Options;

namespace AirportWarehouse.Infrastructure.Service
{
    public class PagedListService<T> : IPagedListService<T>
    {
        public PagedListService(IOptions<PaginationOptions> options)
        {
            _options = options.Value;
        }
        private readonly PaginationOptions _options;
        public PagedResponse<T> Paginate(IEnumerable<T> data, int? pageNumber, int?  pageSize)
        {
            int page = pageNumber ?? _options.DefaultPageNumber;
            int size = pageSize ?? _options.DefaultPageSize;
            return new PagedResponse<T>(data, page, size);
        }
    }
}

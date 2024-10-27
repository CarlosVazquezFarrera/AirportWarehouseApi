using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.Options;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace AirportWarehouse.Infrastructure.Service
{
    public class PagedListService<T> : IPagedListService<T>
    {
        public PagedListService(IOptions<PaginationOptions> options, IMapper mapper)
        {
            _options = options.Value;
            _mapper = mapper;
        }
        private readonly PaginationOptions _options;
        private readonly IMapper _mapper;
        public PagedResponse<T> Paginate(IEnumerable<T> data, int? pageNumber, int?  pageSize)
        {
            int page = pageNumber ?? _options.DefaultPageNumber;
            int size = pageSize ?? _options.DefaultPageSize;
            return new PagedResponse<T>(_mapper.Map<IEnumerable<T>>(data), page, size);
        }
    }
}

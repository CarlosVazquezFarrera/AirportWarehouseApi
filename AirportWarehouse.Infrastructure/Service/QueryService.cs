using AirportWarehouse.Core.CustomEntities;
using AirportWarehouse.Core.DTOs;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace AirportWarehouse.Infrastructure.Service
{
    public class QueryService<TDto> : IQueryService<TDto> where TDto : BaseDTO
    {
        private readonly IPagedListService<TDto> _pagedListService;

        public QueryService(IPagedListService<TDto> pagedListService)
        {
            _pagedListService = pagedListService;
        }

        public PagedResponse<TDto> FilterAndPaginate(IEnumerable<TDto> list, List<Expression<Func<TDto, bool>>> filters, int? pageNumber, int? pageSize)
        {
            var query = list.AsQueryable();
            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }
            return _pagedListService.Paginate(query, pageNumber, pageSize);
        }
    }

}

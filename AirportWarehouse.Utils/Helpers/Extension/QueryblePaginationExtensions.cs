using AirportWarehouse.Core.Dtos;
using AirportWarehouseAdminApi.Core.CustomEntities;
using Microsoft.EntityFrameworkCore;

namespace AirportWarehouse.Utils.Helpers.Extension;

public static class QueryblePaginationExtensions
{
    public static async Task<PagedResult<TResult>> ToPagedResultASync<TResult>(this IQueryable<TResult> query, int page, int pageSize) where TResult : BaseDto
    {
        var totalCount = await query.CountAsync().ConfigureAwait(false);

        var data = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync()
            .ConfigureAwait(false);

        return new PagedResult<TResult>
        {
            Data = data,
            Page = page,
            PageSize = pageSize,
            TotalCount = totalCount
        };

    }
}

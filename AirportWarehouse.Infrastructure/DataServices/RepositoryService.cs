using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Data;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AirportWarehouse.Infrastructure.DataServices;

public class RepositoryService<T> : IRepositoryService<T> where T : BaseEntity
{
    public RepositoryService(AirportwarehouseContext context)
    {
        _context = context;
        _entity = context.Set<T>();
    }

    private readonly AirportwarehouseContext _context;
    protected readonly DbSet<T> _entity;

    private static IQueryable<T> ApplyIncludes(IQueryable<T> query, IEnumerable<Expression<Func<T, object>>>? includes)
    {
        if (includes is null) return query;
        return includes.Aggregate(query, (q, include) => q.Include(include));
    }

    public async Task<IEnumerable<T>> GetAllAsync(IEnumerable<Expression<Func<T, object>>>? includes = null)
    {
        var query = ApplyIncludes(_entity.AsNoTracking(), includes);
        return await query.ToListAsync().ConfigureAwait(false);
    }

    public async Task<T?> GetByIdAsync(Guid Id) => await _entity.FindAsync(Id);

    public async Task<T> CreateAsync(T entity)
    {
        await _entity.AddAsync(entity).ConfigureAwait(false);
        return entity;
    }
    public async Task<T?> UpdateAsync(T entity)
    {
        var existingEntity = await _entity.FindAsync(entity.Id).ConfigureAwait(false);
        if (existingEntity == null) return null;

        _entity.Entry(existingEntity).CurrentValues.SetValues(entity);
        return existingEntity;
    }

    public async Task<bool> DeleteAsync(Guid Id)
    {
        var existingEntity = await _entity.FindAsync(Id).ConfigureAwait(false);
        if (existingEntity == null) return false;

        _entity.Remove(existingEntity);
        return true;
    }

    public async Task<(IEnumerable<T> Data, int totalCount)> GetPagedAsync(int page, int pageZise, Expression<Func<T, bool>>? filter = null, IEnumerable<Expression<Func<T, object>>>? includes = null)
    {
        IQueryable<T> query = ApplyIncludes(_entity.AsNoTracking(), includes);

        if (filter is not null)
            query = query.Where(filter);

        var totalCount = await query.CountAsync().ConfigureAwait(false);

        var data = await query
            .Skip((page - 1) * pageZise)
            .Take(pageZise)
            .ToListAsync()
            .ConfigureAwait(false);

        return (data, totalCount);
    }
    public async Task<T?> GetByConditionAsync(Expression<Func<T, bool>> filter)
    {
        return await _entity.AsNoTracking().FirstOrDefaultAsync(filter).ConfigureAwait(false);
    }
}
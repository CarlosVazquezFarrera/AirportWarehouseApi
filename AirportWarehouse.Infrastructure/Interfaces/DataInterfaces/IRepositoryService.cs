using AirportWarehouse.Core.Entites;
using System.Linq.Expressions;

namespace AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;

public interface IRepositoryService <T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(IEnumerable<Expression<Func<T, object>>>? includes = null);
    Task<T?> GetByIdAsync(Guid Id);
    Task<T?> GetByConditionAsync(Expression<Func<T, bool>> filter);
    Task<T> CreateAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid Id);
    Task<(IEnumerable<T> Data, int totalCount)> GetPagedAsync(
        int page,
        int pageZise,
        Expression<Func<T, bool>>? filter = null,
        IEnumerable<Expression<Func<T, object>>>? includes = null);
}


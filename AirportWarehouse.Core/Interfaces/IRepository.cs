using AirportWarehouse.Core.Entites;
using System.Linq.Expressions;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid Id);
        IQueryable<T> GetAll();
        Task Delete(Guid id);
        Task Add(T entity);
        void Update(T entity);
        Task<T?> GetByCondition(Expression<Func<T, bool>> predicate);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}

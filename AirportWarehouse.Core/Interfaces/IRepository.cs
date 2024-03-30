using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> GetById(Guid Id);
        Task<IEnumerable<T>> GetAll();
        Task Delete(Guid id);
        Task Add(T entity);
        Task Update(T entity);
    }
}

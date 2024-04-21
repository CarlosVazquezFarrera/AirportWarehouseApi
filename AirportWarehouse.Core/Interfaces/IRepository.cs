using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid Id);
        IEnumerable<T> GetAll();
        Task Delete(Guid id);
        Task Add(T entity);
        void Update(T entity);
    }
}

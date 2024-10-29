using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public class BaseRepositoty<T> : IRepository<T> where T : BaseEntity
    {
        public BaseRepositoty(AirportwarehouseContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }
        private readonly AirportwarehouseContext _context;
        protected readonly DbSet<T> _entity;
        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _entity.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetById(Guid Id)
        {
            var entity = await _entity.FindAsync(Id);
            return entity!;
        }

        public async Task Add(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }

        public async Task<T?> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return await _entity.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entity;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.AsQueryable();
        }
    }
}

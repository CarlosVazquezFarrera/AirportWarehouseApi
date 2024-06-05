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
            _entitie = context.Set<T>();
        }
        private readonly AirportwarehouseContext _context;
        protected readonly DbSet<T> _entitie;
        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _entitie.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entitie.AsQueryable();
        }

        public async Task<T> GetById(Guid Id)
        {
            var entity = await _entitie.FindAsync(Id);
            return entity!;
        }

        public async Task Add(T entity)
        {
            await _entitie.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entitie.Update(entity);
        }

        public async Task<T?> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return await _entitie.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entitie;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}

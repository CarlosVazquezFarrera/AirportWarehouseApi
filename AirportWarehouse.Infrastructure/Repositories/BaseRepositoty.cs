using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entitie.ToListAsync();
        }

        public async Task<T?> GetById(Guid Id)
        {
            return await _entitie.FindAsync(Id);
        }

        public async Task Add(T entity)
        {
            _entitie.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entitie.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

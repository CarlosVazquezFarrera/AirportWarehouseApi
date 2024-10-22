using AirportWarehouse.Core.Entites;
using AirportWarehouse.Core.Interfaces;
using AirportWarehouse.Infrastructure.Data;

namespace AirportWarehouse.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AirportwarehouseContext context)
        {
            _context = context;
        }

        private readonly AirportwarehouseContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task SaveChanguesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new BaseRepositoty<T>(_context);
                _repositories.Add(typeof(T), repository);
            }
            return (IRepository<T>)_repositories[typeof(T)];
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}

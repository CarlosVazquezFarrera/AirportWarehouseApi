using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Data;
using AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace AirportWarehouse.Infrastructure.DataServices
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AirportwarehouseContext context)
        {
            _context = context;
        }

        private readonly AirportwarehouseContext _context;
        private readonly Dictionary<Type, object> _repositories = new();
        
        public IRepositoryService<T> Repository<T>() where T : BaseEntity
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new RepositoryService<T>(_context);
                _repositories.Add(typeof(T), repository);
            }
            return (IRepositoryService<T>)_repositories[typeof(T)];
        }
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public Task<IDbContextTransaction> BeginTransactionAsync() => _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            await transaction.CommitAsync();
            await transaction.DisposeAsync();
        }

        public async Task RollbackAsync(IDbContextTransaction transaction)
        {
           await transaction.RollbackAsync();
           await transaction.DisposeAsync();
        }

        public async Task ExecuteTransaction(Func<Task> operation)
        {
            var transaction = await BeginTransactionAsync();
            try
            {
                await operation();
                await SaveChangesAsync();
                await CommitTransactionAsync(transaction);
            }
            catch (Exception)
            {
                await RollbackAsync(transaction);
                throw;
            }
        }

        public void Dispose() => _context.Dispose();
    }
}

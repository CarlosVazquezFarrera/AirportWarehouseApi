using AirportWarehouse.Core.Entites;
using Microsoft.EntityFrameworkCore.Storage;

namespace AirportWarehouse.Infrastructure.Interfaces.DataInterfaces;

public interface IUnitOfWork 
{
    IRepositoryService<T> Repository<T>() where T : BaseEntity;
    Task SaveChangesAsync();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync(IDbContextTransaction transaction);
    Task RollbackAsync(IDbContextTransaction transaction);
    Task ExecuteTransaction(Func<Task> operation);
}

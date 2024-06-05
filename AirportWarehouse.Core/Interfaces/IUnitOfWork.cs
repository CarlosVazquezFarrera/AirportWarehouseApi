using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Egress> EgressRepository { get; }
        IRepository<Supply> SupplyRepository { get; }
        IRepository<Agent> AgentRepository { get; }
        IRepository<Airport> AirportRepository { get; }
        IRepository<Entry> EntryRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Permission> PermissionRepository { get; }
        IRepository<AgentPermission> AgentPermissionRepository { get; }



        Task SaveChanguesAsync();
    }
}

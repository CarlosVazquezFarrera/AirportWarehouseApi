using AirportWarehouse.Core.Entites;

namespace AirportWarehouse.Core.Interfaces
{
    public interface IEntryService
    {
        Task<Entry> Create(Entry entry);

    }
}

using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

namespace AirportWarehouse.Controllers
{
    public class EntryController : GenericController<Entry, EntryDto>
    {
        public EntryController(IGenericService<Entry, EntryDto> service) : base(service)
        {
        }
    }
}

using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

namespace AirportWarehouse.Controllers
{
    public class PackagingTypeController : GenericGetController<PackagingType, PackagingTypeDto>
    {
        public PackagingTypeController(IGenericService<PackagingType, PackagingTypeDto> service) : base(service)
        {
        }
    }
}

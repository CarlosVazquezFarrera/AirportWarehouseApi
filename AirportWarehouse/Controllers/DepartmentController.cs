using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

namespace AirportWarehouse.Controllers
{
    public class DepartmentController : GenericGetController<Department, DepartmentDto>
    {
        public DepartmentController(IGenericService<Department, DepartmentDto> service) : base(service)
        {
        }
    }
}

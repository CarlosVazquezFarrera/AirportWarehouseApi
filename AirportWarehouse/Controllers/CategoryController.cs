using AirportWarehouse.Core.Dtos;
using AirportWarehouse.Core.Entites;
using AirportWarehouse.Infrastructure.Interfaces.ServiceInterfaces;

namespace AirportWarehouse.Controllers
{    public class CategoryController : GenericGetController<Category, CategoryDto>
    {
        public CategoryController(IGenericService<Category, CategoryDto> service) : base (service)
        {
        }
    }
}

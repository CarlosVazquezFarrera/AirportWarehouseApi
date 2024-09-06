using AirportWarehouse.Core.ExtentionEntities;

namespace AirportWarehouse.Core.CustomEntities
{
    public class PagedResponse<T>
    {
        public PagedResponse(IEnumerable<T> items, int pageNumber, int pageSize)
        {
            Data = new PagedList<T>(items, pageNumber, pageSize);
            Metadata = new Metadata<T>(Data, items.Count());
        }

        public PagedList<T> Data { get; set; }
        public Metadata<T> Metadata { get; set; }

    }
}

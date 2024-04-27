using AirportWarehouse.Core.CustomEntities;

namespace AirportWarehouse.Core.ExtentionEntities
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            PageSize = pageSize;
            CurrentPage = pageNumber;
            AddRange(items);
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

    }
}

using AirportWarehouse.Core.ExtentionEntities;

namespace AirportWarehouse.Core.CustomEntities
{
    public class Metadata<T>
    {
        public Metadata(PagedList<T> items)
        {
            TotalCount = items.Count;
            PageSize = items.PageSize;
            CurrentPage = items.CurrentPage;
        }
        public int TotalCount { get; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

    }
}

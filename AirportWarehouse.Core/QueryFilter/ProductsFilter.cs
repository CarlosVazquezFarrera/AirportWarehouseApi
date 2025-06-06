﻿namespace AirportWarehouse.Core.QueryFilter
{
    public class ProductsFilter : BasePagedParameter, IFilterParameter
    {
        public Guid AirportId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ProductFormatId { get; set; }
        public Guid PackagingTypeId { get; set; }
        public string? Search {get; set; }
    }
}

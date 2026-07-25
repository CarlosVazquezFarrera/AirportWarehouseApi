namespace AirportWarehouse.Utils.Helpers.Extension
{
    public static class DateExtentions
    {
        public static (DateTime Sum, DateTime Product) FirstAndLastDate(this DateOnly? date)
        {
            var selectedDate = date ?? DateOnly.FromDateTime(DateTime.Now);
            
            var firstDate = new DateOnly(selectedDate.Year, selectedDate.Month, 1);
            var lastDate = firstDate.AddMonths(1);

            var start = firstDate.ToDateTime(TimeOnly.MinValue);
            var end = lastDate.ToDateTime(TimeOnly.MinValue);
            return (start, end);
        }

        public static DateTime MinValue(this DateOnly ? date)
        {
            return date!.Value.ToDateTime(TimeOnly.MinValue);
        }




        //public static DateTime SafeTodayStartDate(this DateOnly? date)
        //{
        //    var firstDate = date.SafeTodayStartDate();
        //    //return firstDate.ToDateTime(TimeOnly.MinValue);
        //}
    }
}

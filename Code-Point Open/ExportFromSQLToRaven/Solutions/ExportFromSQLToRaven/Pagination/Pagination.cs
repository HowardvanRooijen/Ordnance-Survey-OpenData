namespace ExportFromSQLToMongo.Pagination
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Pagination class holding paged list converter helper methods
    /// </summary>
    public static class Pagination 
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize) 
        {
            return new PagedList<T>(source, pageIndex, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize) 
        {
            return new PagedList<T>(source, pageIndex, pageSize);
        }

        public static List<PagedList<T>> CreateBatchesOf<T>(this IEnumerable<T> items, int batchSize)
        {
            var batches = new List<PagedList<T>>();

            int pageIndex = 0;

            PagedList<T> batch = items.ToPagedList(pageIndex, batchSize);
            int pageCount = batch.PageCount;

            while (pageIndex < pageCount)
            {
                batches.Add(batch);
                pageIndex++;
                batch = items.ToPagedList(pageIndex, batchSize);
            }

            return batches;
        }
    }
}
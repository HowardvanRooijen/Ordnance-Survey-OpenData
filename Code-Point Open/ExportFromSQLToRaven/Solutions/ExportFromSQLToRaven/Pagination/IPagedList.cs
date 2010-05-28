namespace ExportFromSQLToMongo.Pagination
{
    /// <summary>A Paged List Interface</summary>
    public interface IPagedList 
    {
        /// <summary>The total number of pages</summary>
        int PageCount { get; }
        
        /// <summary>The total number of items in the set</summary>
        int TotalItemCount { get; }
        
        /// <summary>The current page index</summary>
        int PageIndex { get; }
        
        /// <summary>The current page number</summary>
        int PageNumber { get; }
        
        /// <summary>The number of items in a page</summary>
        int PageSize { get; }
        
        /// <summary>Whether or not a previous page exists</summary>
        bool HasPreviousPage { get; }
        
        /// <summary>Whether or not a next page exists</summary>
        bool HasNextPage { get; }
        
        /// <summary>Whether or not the current page is the first</summary>
        bool IsFirstPage { get; }
        
        /// <summary>Whether or not the current page is the last</summary>
        bool IsLastPage { get; }
    }
}
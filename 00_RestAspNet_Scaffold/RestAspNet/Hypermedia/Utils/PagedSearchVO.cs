using RestAspNet.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestAspNet.Hypermedia.Utils
{
    public class PagedSearchVO<T> where T : ISupportHypermedia 
    {
        public int CurrentPage { get; set; }
        public int Size { get; set; }
        public int TotalResults { get; set; }
        public string SortFields { get; set; }
        public string SortDirections { get; set; }
        public Dictionary<string, object> Filters { get; set; }
        public List<T> List { get; set; }

        public PagedSearchVO() { }

        public PagedSearchVO(int currentPage, int size, string sortFields, string sortDirections)
        {
            CurrentPage = currentPage;
            Size = size;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchVO(int currentPage, int size, string sortFields, string sortDirections, Dictionary<string, object> filters) 
        {
            CurrentPage = currentPage;
            Size = size;
            SortFields = sortFields;
            SortDirections = sortDirections;
            Filters = filters;
        }

        public PagedSearchVO(int currentPage, string sortFields, string sortDirections) 
            : this (currentPage, 10, sortFields, sortDirections) { }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetSize()
        {
            return Size == 0 ? 10 : Size;
        }
    }
}

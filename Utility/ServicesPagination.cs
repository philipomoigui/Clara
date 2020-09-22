using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Utility
{
    public class ServicesPagination<T> : List<T> 
    {
        public ServicesPagination(List<T> items, int count, int pageIndex, int pagesize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pagesize);
            this.AddRange(items);
        }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public bool IsPreviousPageAvailable => PageIndex > 1;
        public bool IsNextPageAvailable => PageIndex < TotalPages;

        public static ServicesPagination<T> Create(IList<T> source, int pageSize, int pageIndex)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new ServicesPagination<T>(items, count, pageIndex, pageSize);
        }
    }
}

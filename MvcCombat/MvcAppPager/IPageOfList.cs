using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppPager
{
    public interface IPageOfList
    {
        long CurrentStart { get; }
        long CurrentEnd { get; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int PageTotal { get; }
        long RecordTotal { get; set; }
    }
    public interface IPageOfList<T> : IPageOfList, IList<T>
    { }

    public class PageOfList<T> : List<T>, IList<T>, IPageOfList, IPageOfList<T>
    {
        public PageOfList(IEnumerable<T> item, int pageIndex, int pageSize, long recordTotal)
        {
            if (item != null)
            {
                AddRange(item);
            }
            PageIndex = pageIndex;
            PageSize = pageSize;
            RecordTotal = recordTotal;
        }
        public PageOfList(int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException("pageSize must gart 0", "pageSize");
            }
        }
        public long CurrentEnd 
        {
            get
            {
                return (PageIndex + 1) * PageSize > RecordTotal ? RecordTotal : (PageIndex + 1) * PageSize;
            }
        }
        public long CurrentStart
        {
            get
            {
                return PageIndex * PageSize + 1;
            }
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageTotal
        {
            get
            {
                return (int)RecordTotal / PageSize + (RecordTotal % PageSize > 0 ? 1 : 0);
            }
        }

        public long RecordTotal { get; set; }
    }
}
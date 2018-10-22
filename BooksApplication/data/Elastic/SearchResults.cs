using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.data.Elastic
{
   public class SearchResult<T>
    {
        public long Total { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<T> Results { get; set; }

        public long ElapsedMilliseconds { get; set; }
    }
}

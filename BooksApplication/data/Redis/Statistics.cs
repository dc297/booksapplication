using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.data.Redis
{
    public class Statistics
    {
        public string IpRequestCount { get; set; }

        public string BookCount { get; set; }

        public string AuthorCount { get; set; }
    }
}

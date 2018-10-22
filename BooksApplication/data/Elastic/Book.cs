using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.data.Elastic
{
    [ElasticsearchType(Name = "recipe")]
    public class Book
    {
        public int Id;

        [Completion]
        public string Name { get; set; }

        [Text]
        public string Description { get; set; }

        [Completion]
        public string Authorname { get; set; }
    }
}

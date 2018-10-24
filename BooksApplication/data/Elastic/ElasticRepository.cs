using BooksApplication.data.Postgres;
using Microsoft.Extensions.Options;
using Nest;

namespace BooksApplication.data.Elastic
{
    public class ElasticRepository : IElasticRepository
    {
        ElasticClient _client;
        string index;
        public ElasticRepository(ElasticClientProvider provider)
        {
            _client = provider.Client;
            index = "book";
        }

        public void AddAuthorWithBook(Author author)
        {
            Book book = new Book { Authorname= author.Name };
            BooksApplication.data.Postgres.Book postgreBook = author.Books[0];

            book.Name = postgreBook.Name;
            book.Id = postgreBook.Id;
            book.Description = postgreBook.Description;

            var indexDescriptor = new CreateIndexDescriptor(index)
                    .Mappings(mappings => mappings
                        .Map<Book>(m => m.AutoMap()));
            _client.CreateIndex(index, i=> indexDescriptor);

            _client.Index<Book>(book, i => i.Index(index));
        }
    }
}

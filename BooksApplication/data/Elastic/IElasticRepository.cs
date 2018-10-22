using BooksApplication.data.Postgres;

namespace BooksApplication.data.Elastic
{
    public interface IElasticRepository
    {
        void AddAuthorWithBook(Author author);
    }
}

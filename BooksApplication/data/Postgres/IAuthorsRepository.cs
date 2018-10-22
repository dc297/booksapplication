using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.data.Postgres
{
    public interface IAuthorsRepository
    {
        IEnumerable<Author> GetAllAuthors();

        Author GetAuthorById(int Id);

        void AddAuthorWithBook(Author author);

        bool Save();
    }
}

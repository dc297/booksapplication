using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BooksApplication.data.Postgres
{
    public class AuthorsRepository : IAuthorsRepository
    {
        AuthorContext _context;

        public AuthorsRepository(AuthorContext booksContext)
        {
            _context = booksContext;
        }

        public void AddAuthorWithBook(Author author)
        {
            Author checkIfExists = _context.Author.Where(a => a.Name == author.Name).FirstOrDefault();
            if(checkIfExists!=null)
            {
                author.Id = checkIfExists.Id;
                author.modified = true;
                foreach (Book book in author.Books)
                {
                    book.AuthorId = checkIfExists.Id;
                    _context.Add(book);
                }
            }
            else _context.Author.Add(author);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Author.Include(b => b.Books).ToList();
        }

        public Author GetAuthorById(int Id)
        {
            return _context.Author.Where(author => author.Id.Equals(Id)).Include(author => author.Books).FirstOrDefault();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

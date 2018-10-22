using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.data.Postgres
{
    public class Author
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [NotMapped]
        public Boolean modified { get; set; }
        public IList<Book> Books { get; set; }
    }
}

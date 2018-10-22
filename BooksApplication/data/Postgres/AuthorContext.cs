using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.data.Postgres
{
    public class AuthorContext : DbContext { 

        public AuthorContext(DbContextOptions<AuthorContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasIndex(b => b.Name)
                .IsUnique();
        }
        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

    }
}

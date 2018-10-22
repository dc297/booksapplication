﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.data.Postgres
{
    public class Book
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CoverId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author;
    }
}

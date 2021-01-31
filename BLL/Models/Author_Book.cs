using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Author_BookModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
        public Author_BookModel() { }
        public Author_BookModel(Author_Book ab)
        {
            BookId = ab.BookId;
            AuthorId = ab.AuthorId;
            Book = ab.Book;
            Author = ab.Author;
        }
    }
}


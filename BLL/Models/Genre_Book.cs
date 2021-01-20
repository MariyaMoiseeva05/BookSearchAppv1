using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class Genre_BookModel
    {
        public int BookId { get; set; }

        public int GenreId { get; set; }
        public Book Book { get; set; }
        public Genre Genre { get; set; }
        public Genre_BookModel() { }
        public Genre_BookModel(Genre_Book gb)
        {
            BookId = gb.BookId;
            GenreId = gb.GenreId;
            Book = gb.Book;
            Genre = gb.Genre;

        }
    }
}

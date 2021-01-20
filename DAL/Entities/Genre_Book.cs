using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Genre_Book
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

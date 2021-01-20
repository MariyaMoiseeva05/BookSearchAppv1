using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Genre_Author
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}

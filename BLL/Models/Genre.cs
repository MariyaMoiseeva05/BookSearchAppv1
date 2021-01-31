using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class GenreModel
    {
        public int GenreId { get; set; }
        public string NameGenre { get; set; }
        public virtual ICollection<Genre_Book> Genre_Books { get; set; }
        public GenreModel() { }
        public GenreModel(Genre g)
        {
            GenreId = g.GenreId;
            NameGenre = g.NameGenre;
            Genre_Books = g.Genre_Books;

        }
    }
}

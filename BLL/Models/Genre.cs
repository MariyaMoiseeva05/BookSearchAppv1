using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class GenreModel
    {
        public int GenreId { get; set; }
        public string NameGenre { get; set; }
        public ICollection<Genre_Book> Genre_Books { get; set; }
        public ICollection<Genre_Author> Author { get; set; }
        public ICollection<Genre_TypeLit> Type_of_literature { get; set; }
        public GenreModel() { }
        public GenreModel(Genre g)
        {
            GenreId = g.GenreId;
            NameGenre = g.NameGenre;
            Genre_Books = g.Genre_Books;
            Author = g.Author;
            Type_of_literature = g.Type_of_literature;

        }
    }
}

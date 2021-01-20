using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class GenreRepositorySQL : IRepository<Genre>
    {
        private BookSearchContext db;
        public GenreRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Genre Genre)
        {
            db.Genres.Add(Genre);
        }

        public void Delete(int? id)
        {
            Genre Genre = db.Genres.Find(id);
            if (Genre != null)
                db.Genres.Remove(Genre);
        }

        public Genre GetItem(int? id)
        {
            return db.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        public void Update(Genre Genre, int? genreId)
        {
            var gr = db.Genres.Find(genreId);
            gr.NameGenre = Genre.NameGenre;
            gr.Genre_Books = Genre.Genre_Books;

            db.Genres.Update(gr);
            db.SaveChanges();
        }
    }
}

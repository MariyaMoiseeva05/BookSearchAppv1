using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public object Create(Genre Genre)
        {
            db.Genres.Add(Genre);
            db.SaveChanges();
            return Genre.GenreId;
        }

        public void Delete(object id)
        {
            Genre Genre = db.Genres.Find((int)id);
            if (Genre != null)
                db.Genres.Remove(Genre);
        }

        public Genre GetItem(object id)
        {
            return db.Genres
                .Include(g => g.Genre_Books).ThenInclude(gn => gn.Book)
                .SingleOrDefault(b => b.GenreId == (int)id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres
               .Include(g => g.Genre_Books).ThenInclude(gn => gn.Book)
                .ToList();
        }

        public void Update(Genre Genre, object genreId)
        {
            var gr = db.Genres.Find((int)genreId);
            gr.NameGenre = Genre.NameGenre;
            gr.Genre_Books = Genre.Genre_Books;

            db.Genres.Update(gr);
            db.SaveChanges();
        }
    }
}

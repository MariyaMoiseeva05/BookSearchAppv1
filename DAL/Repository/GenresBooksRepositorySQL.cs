using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class GenresBooksRepositorySQL : IRepository<Genre_Book>
    {
        private BookSearchContext db;
        public GenresBooksRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(Genre_Book Genre_Book)
        {
            db.Genre_Books.Add(Genre_Book);
            db.SaveChanges();
            return Genre_Book.GenreId;
        }

        public void Delete(object id)
        {
            Genre_Book Genre_Book = db.Genre_Books.Find((int)id);
            if (Genre_Book != null)
                db.Genre_Books.Remove(Genre_Book);
        }

        public Genre_Book GetItem(object id)
        {
            return db.Genre_Books.Find((int)id);
        }

        public IEnumerable<Genre_Book> GetAll()
        {
            return db.Genre_Books.ToList();
        }

        public void Update(Genre_Book Genre_Book, object id)
        {
            var cn = db.Genre_Books.Find((int)id);
            cn.GenreId = Genre_Book.GenreId;
            cn.BookId = Genre_Book.BookId;

            db.Genre_Books.Update(cn);
            db.SaveChanges();
        }
    }
}

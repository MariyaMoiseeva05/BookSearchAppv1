using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Author_BookRepositorySQL : IRepository<Author_Book>
    {
        private BookSearchContext db;
        public Author_BookRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(Author_Book Author_Book)
        {
            db.Author_Books.Add(Author_Book);
            db.SaveChanges();
            return Author_Book.AuthorId;
        }

        public void Delete(object id)
        {
            Author_Book Author_Book = db.Author_Books.Find((int)id);
            if (Author_Book != null)
                db.Author_Books.Remove(Author_Book);
        }

        public Author_Book GetItem(object id)
        {
            return db.Author_Books.Find((int)id);
        }

        public IEnumerable<Author_Book> GetAll()
        {
            return db.Author_Books.ToList();
        }

        public void Update(Author_Book Author_Book, object id)
        {
            var cn = db.Author_Books.Find((int)id);
            cn.AuthorId = Author_Book.AuthorId;
            cn.BookId = Author_Book.BookId;

            db.Author_Books.Update(cn);
            db.SaveChanges();
        }
    }
}

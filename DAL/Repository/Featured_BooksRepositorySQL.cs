using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Featured_BooksRepositorySQL :IRepository<Featured_Book>
    {
        private BookSearchContext db;
        public Featured_BooksRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Featured_Book Featured_Book)
        {
            db.Featured_Books.Add(Featured_Book);
            db.SaveChanges();
        }

        public void Delete(object featBookId)
        {
            var featbook = db.Featured_Books.FirstOrDefault(x => x.Featured_BookId == (int)featBookId);

            if (featbook != null)
            {
                db.Featured_Books.Remove(featbook);
                db.SaveChanges();
            }
        }

        public Featured_Book GetItem(object id)
        {
            return db.Featured_Books.Find((int)id);
        }

        public IEnumerable<Featured_Book> GetAll()
        {
            return db.Featured_Books.ToList();
        }

        public void Update(Featured_Book Featured_Book, object featbookId)
        {
            var featbook = db.Featured_Books.Find((int)featbookId);

            featbook.UserId = Featured_Book.UserId;
            featbook.BookId = Featured_Book.BookId;

            db.Featured_Books.Update(featbook);
            db.SaveChanges();
        }
    }
}

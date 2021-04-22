using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class BookRepositorySQL : IRepository<Book>
    {
        private BookSearchContext db;
        public BookRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(Book Book)
        {
            db.Books.Add(Book);
            db.SaveChanges();
            return Book.BookID;
        }

        public void Delete(object bookId)
        {
            var book = db.Books.FirstOrDefault(x => x.BookID == (int)bookId);

            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public Book GetItem(object id)
        {
            return db.Books
                .Include(r => r.Reviews)
                .Include(q => q.Quotes)
                .Include(ad => ad.Adverts)
                .Include(a =>a.Authors).ThenInclude(gn => gn.Author)
                .Include(t => t.Types_of_literature).ThenInclude(gn => gn.TypeLit)
                .Include(g => g.Genres_Books).ThenInclude(gn => gn.Genre)
                .Include(cl => cl.Book_Collections).ThenInclude(gn => gn.Collection)
                .Include(ch => ch.Book_Characters).ThenInclude(gn => gn.Character)
                .SingleOrDefault(b => b.BookID == (int)id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books
                .Include(a => a.Authors).ThenInclude(gn => gn.Author)
                .Include(t => t.Types_of_literature).ThenInclude(gn => gn.TypeLit)
                .Include(g => g.Genres_Books).ThenInclude(gn => gn.Genre)
                .Include(cl => cl.Book_Collections).ThenInclude(gn => gn.Collection)
                .Include(ch => ch.Book_Characters).ThenInclude(gn => gn.Character)
                .ToList();
        }

        public void Update(Book Book, object bookId)
        {
            var book = db.Books.Find((int)bookId);
            book.Title = Book.Title;
            book.Authors = Book.Authors;
            book.Description = Book.Description;
            book.Story = Book.Story;
            book.Edition = Book.Edition;
            book.Publication_date = Book.Publication_date;
            book.ImagePath = Book.ImagePath;
            book.ImageLink = Book.ImageLink;
            book.Quotes = Book.Quotes;
            book.Reviews = Book.Reviews;
            book.Screenings = Book.Screenings;
            book.Types_of_literature = Book.Types_of_literature;
            book.Genres_Books = Book.Genres_Books;
            book.Book_Characters = Book.Book_Characters;
            book.Book_Collections = Book.Book_Collections;
            book.Adverts = Book.Adverts;
            book.Featured_Books = Book.Featured_Books;

            db.Books.Update(book);
            db.SaveChanges();

        }
    }
}

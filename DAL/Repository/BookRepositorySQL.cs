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
        public void Create(Book Book)
        {
            db.Books.Add(Book);
            db.SaveChanges();

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
                .Include(c => c.Comment)
                .Include(r => r.Review)
                .Include(q => q.Quote)
                .Include(a =>a.Author).ThenInclude(gn => gn.Author)
                .Include(t => t.Type_of_literature).ThenInclude(gn => gn.TypeLit)
                .Include(g => g.Genre_Books).ThenInclude(gn => gn.Genre)
                .Include(cl => cl.Book_Collections).ThenInclude(gn => gn.Collection)
                .Include(ch => ch.Book_Characters).ThenInclude(gn => gn.Character)
                .First(b => b.BookID == (int)id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books
                .Include(a => a.Author).ThenInclude(gn => gn.Author)
                .Include(t => t.Type_of_literature).ThenInclude(gn => gn.TypeLit)
                .Include(g => g.Genre_Books).ThenInclude(gn => gn.Genre)
                .Include(cl => cl.Book_Collections).ThenInclude(gn => gn.Collection)
                .Include(ch => ch.Book_Characters).ThenInclude(gn => gn.Character)
                .ToList();
        }

        public void Update(Book Book, object bookId)
        {
            var book = db.Books.Find((int)bookId);
            book.Title = Book.Title;
            book.Author = Book.Author;
            book.Description = Book.Description;
            book.Story = Book.Story;
            book.Edition = Book.Edition;
            book.Publication_date = Book.Publication_date;
            book.ImagePath = Book.ImagePath;
            book.ImageLink = Book.ImageLink;
            book.Comment = Book.Comment;
            book.Quote = Book.Quote;
            book.Review = Book.Review;
            book.Screenings = Book.Screenings;
            book.Type_of_literature = Book.Type_of_literature;
            book.Genre_Books = Book.Genre_Books;
            book.Book_Characters = Book.Book_Characters;
            book.Book_Collections = Book.Book_Collections;


            db.Books.Update(book);
            db.SaveChanges();

        }
    }
}

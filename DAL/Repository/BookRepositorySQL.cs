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

        public void Delete(int? bookId)
        {
            var book = db.Books.FirstOrDefault(x => x.BookID == bookId);

            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public Book GetItem(int? id)
        {
            return db.Books
                .Include(c => c.Comment)
                .Include(a => a.Author)
                .Include(r => r.Review)
                .Include(q => q.Quote)
                .Include(t => t.Type_of_literature).ThenInclude(gn => gn.TypeLit)
                .Include(g => g.Genre_Books).ThenInclude(gn => gn.Genre)
                .First(b => b.BookID == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books
                .Include(a => a.Author)
                .Include(t => t.Type_of_literature).ThenInclude(gn => gn.TypeLit)
                .Include(g => g.Genre_Books).ThenInclude(gn => gn.Genre)
                .ToList();
        }

        public void Update(Book Book, int? bookId)
        {
            var book = db.Books.Find(bookId);
            book.Title = Book.Title;
            book.AuthorID = Book.AuthorID;
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


            db.Books.Update(book);
            db.SaveChanges();

        }
    }
}

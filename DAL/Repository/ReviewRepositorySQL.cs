using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ReviewRepositorySQL : IRepository<Review>
    {
        private BookSearchContext db;
        public ReviewRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Review Review)
        {
            db.Reviews.Add(Review);
        }

        public void Delete(int? id)
        {
            Review Review = db.Reviews.Find(id);
            if (Review != null)
                db.Reviews.Remove(Review);
        }

        public Review GetItem(int? id)
        {
            return db.Reviews.Find(id);
        }

        public IEnumerable<Review> GetAll()
        {
            return db.Reviews.ToList();
        }

        public void Update(Review Review, int? reviewId)
        {
            var rw = db.Reviews.Find(reviewId);

            rw.Title = Review.Title;
            rw.Text = Review.Text;
            rw.Type = Review.Type;
            rw.BookID = Review.BookID;
           // rw.UserID = Review.UserID;
            rw.Book = Review.Book;
            rw.Rating = Review.Rating;
            rw.Comments = Review.Comments;

            db.Reviews.Update(rw);
            db.SaveChanges();
        }
    }
}

using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Comment_ReviewRepositorySQL : IRepository<Comment_Review>
    {
        private BookSearchContext db;
        public Comment_ReviewRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(Comment_Review Comment_Review)
        {
            db.Comments_Review.Add(Comment_Review);
            db.SaveChanges();
            return Comment_Review.Comment_ReviewId;
        }

        public void Delete(object commentId)
        {
            var comment_review = db.Comments_Review.FirstOrDefault(x => x.Comment_ReviewId == (int)commentId);

            if (comment_review != null)
            {
                db.Comments_Review.Remove(comment_review);
                db.SaveChanges();
            }
        }

        public Comment_Review GetItem(object id)
        {
            return db.Comments_Review.Find((int)id);
        }

        public IEnumerable<Comment_Review> GetAll()
        {
            return db.Comments_Review.ToList();
        }

        public void Update(Comment_Review Comment_Review, object comment_reviewId)
        {
            var cr = db.Comments_Review.Find((int)comment_reviewId);
            cr.UserId = Comment_Review.UserId;
            cr.ReviewId = Comment_Review.ReviewId;
            cr.Content = Comment_Review.Content;
            cr.Date_of_creation = Comment_Review.Date_of_creation;
            cr.Review = Comment_Review.Review;
            cr.User = Comment_Review.User;

            db.Comments_Review.Update(cr);
            db.SaveChanges();
        }
    }
}


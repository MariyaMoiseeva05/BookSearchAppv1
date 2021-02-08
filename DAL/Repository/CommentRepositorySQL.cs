using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class CommentRepositorySQL : IRepository<Comment>
    {
        private BookSearchContext db;
        public CommentRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Comment Comment)
        {
            db.Comments.Add(Comment);
            db.SaveChanges();
        }

        public void Delete(object commentId)
        {
            var comment = db.Comments.FirstOrDefault(x => x.CommentId == (int)commentId);
            if (comment != null)
            {
                db.Comments.Remove(comment);
                db.SaveChanges();
            }
        }

        public Comment GetItem(object id)
        {
            return db.Comments.Find((int)id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments.ToList();
        }

        public void Update(Comment Comment, object commentId)
        {
            var cm = db.Comments.Find((int)commentId);
            cm.UserId = Comment.UserId;
            cm.Content = Comment.Content;
            cm.Date_of_creation = Comment.Date_of_creation;
            cm.Book = Comment.Book;
            cm.Rating = Comment.Rating;

            db.Comments.Update(cm);
            db.SaveChanges();
        }
    }
}

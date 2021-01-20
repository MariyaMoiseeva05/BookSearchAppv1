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
        }

        public void Delete(int? id)
        {
            Comment Comment = db.Comments.Find(id);
            if (Comment != null)
                db.Comments.Remove(Comment);
        }

        public Comment GetItem(int? id)
        {
            return db.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return db.Comments.ToList();
        }

        public void Update(Comment Comment, int? commentId)
        {
            var cm = db.Comments.Find(commentId);
           // cm.UserId = Comment.UserId;
            cm.Content = Comment.Content;
            cm.Title = Comment.Title;
            cm.Date_of_creation = Comment.Date_of_creation;
            cm.Book = Comment.Book;
            cm.Rating = Comment.Rating;

            db.Comments.Update(cm);
            db.SaveChanges();
        }
    }
}

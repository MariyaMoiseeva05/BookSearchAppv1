using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Comment_NewsRepositorySQL : IRepository <Comment_News>
    {
        private BookSearchContext db;
        public Comment_NewsRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(Comment_News Comment_News)
        {
            db.Comments_News.Add(Comment_News);
            db.SaveChanges();
            return Comment_News.Comment_NewsId;
        }

        public void Delete(object id)
        {
            Comment_News Comment_News = db.Comments_News.Find((int)id);
            if (Comment_News != null)
                db.Comments_News.Remove(Comment_News);
        }

        public Comment_News GetItem(object id)
        {
            return db.Comments_News.Find((int)id);
        }

        public IEnumerable<Comment_News> GetAll()
        {
            return db.Comments_News.ToList();
        }

        public void Update(Comment_News Comment_News, object comment_newsId)
        {
            var cn = db.Comments_News.Find((int)comment_newsId);
            cn.UserId = Comment_News.UserId;
            cn.NewsId = Comment_News.NewsId;
            cn.Content = Comment_News.Content;
            cn.Date_of_creation = Comment_News.Date_of_creation;
            cn.News = Comment_News.News;
            cn.User = Comment_News.User;

            db.Comments_News.Update(cn);
            db.SaveChanges();
        }
    }
}

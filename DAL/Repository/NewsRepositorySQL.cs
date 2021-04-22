using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class NewsRepositorySQL : IRepository<News>
    {
        private BookSearchContext db;
        public NewsRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(News News)
        {
            db.News.Add(News);
            db.SaveChanges();
            return News.NewsId;
        }

        public void Delete(object id)
        {
            News News = db.News.Find((int)id);
            if (News != null)
                db.News.Remove(News);
        }

        public News GetItem(object id)
        {
            return db.News.Find((int)id);
        }

        public IEnumerable<News> GetAll()
        {
            return db.News.ToList();
        }

        public void Update(News News, object newsId)
        {
            var nw = db.News.Find((int)newsId);

            nw.Topic = News.Topic;
            nw.Title = News.Title;
            nw.Date_of_creation = News.Date_of_creation;
            nw.Content = News.Content;
            nw.ImageLink = News.ImageLink;
            nw.ImagePath = News.ImagePath;
            nw.Tags = News.Tags;
            nw.Source = News.Source;
            nw.Comments = News.Comments;

            db.News.Update(nw);
            db.SaveChanges();
        }
    }
}

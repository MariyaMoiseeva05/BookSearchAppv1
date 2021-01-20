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
        public void Create(News News)
        {
            db.News.Add(News);
        }

        public void Delete(int? id)
        {
            News News = db.News.Find(id);
            if (News != null)
                db.News.Remove(News);
        }

        public News GetItem(int? id)
        {
            return db.News.Find(id);
        }

        public IEnumerable<News> GetAll()
        {
            return db.News.ToList();
        }

        public void Update(News News, int? newsId)
        {
            var nw = db.News.Find(newsId);

            nw.Topic = News.Topic;
            nw.Title = News.Title;
            nw.Date_of_creation = News.Date_of_creation;
            nw.Content = News.Content;
            nw.ImageLink = News.ImageLink;
            nw.ImagePath = News.ImagePath;
            nw.Tags = News.Tags;

            db.News.Update(nw);
            db.SaveChanges();
        }
    }
}

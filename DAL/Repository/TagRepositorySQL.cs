using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class TagRepositorySQL : IRepository<Tag>
    {
        private BookSearchContext db;
        public TagRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Tag Tags)
        {
            db.Tags.Add(Tags);
        }

        public void Delete(int? id)
        {
            Tag Tags = db.Tags.Find(id);
            if (Tags != null)
                db.Tags.Remove(Tags);
        }

        public Tag GetItem(int? id)
        {
            return db.Tags.Find(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags.ToList();
        }

        public void Update(Tag Tags, int? tagsId)
        {
            var tg = db.Tags.Find(tagsId);

            tg.Name = Tags.Name;
            tg.News = Tags.News;

            db.Tags.Update(tg);
            db.SaveChanges();
        }
    }
}
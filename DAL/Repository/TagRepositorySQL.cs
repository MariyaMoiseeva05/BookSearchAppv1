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
        public object Create(Tag Tags)
        {
            db.Tags.Add(Tags);
            db.SaveChanges();
            return Tags.Id;
        }

        public void Delete(object id)
        {
            Tag Tags = db.Tags.Find((int)id);
            if (Tags != null)
                db.Tags.Remove(Tags);
        }

        public Tag GetItem(object id)
        {
            return db.Tags.Find((int)id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags.ToList();
        }

        public void Update(Tag Tags, object tagsId)
        {
            var tg = db.Tags.Find((int)tagsId);

            tg.Name = Tags.Name;
            tg.News = Tags.News;

            db.Tags.Update(tg);
            db.SaveChanges();
        }
    }
}
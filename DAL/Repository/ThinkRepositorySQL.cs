using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ThinkRepositorySQL : IRepository<Think>
    {
        private BookSearchContext db;
        public ThinkRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(Think Think)
        {
            db.Thinks.Add(Think);
            db.SaveChanges();
            return Think.ThinkId;
        }

        public void Delete(object id)
        {
            Think Think = db.Thinks.Find((int)id);
            if (Think != null)
                db.Thinks.Remove(Think);
        }

        public Think GetItem(object id)
        {
            return db.Thinks.Find((int)id);
        }

        public IEnumerable<Think> GetAll()
        {
            return db.Thinks.ToList();
        }

        public void Update(Think Think, object thinkId)
        {
            var th = db.Thinks.Find((int)thinkId);
            th.Title = Think.Title;
            th.Content = Think.Content;
            th.Date_of_creation = Think.Date_of_creation;

            db.Thinks.Update(th);
            db.SaveChanges();
        }
    }
}

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
        public void Create(Think Think)
        {
            db.Thinks.Add(Think);
        }

        public void Delete(int? id)
        {
            Think Think = db.Thinks.Find(id);
            if (Think != null)
                db.Thinks.Remove(Think);
        }

        public Think GetItem(int? id)
        {
            return db.Thinks.Find(id);
        }

        public IEnumerable<Think> GetAll()
        {
            return db.Thinks.ToList();
        }

        public void Update(Think Think, int? thinkId)
        {
            var th = db.Thinks.Find(thinkId);
            th.Title = Think.Title;
            th.Content = Think.Content;
            th.Date_of_creation = Think.Date_of_creation;
            //th.UserId = Think.UserId;

            db.Thinks.Update(th);
            db.SaveChanges();
        }
    }
}

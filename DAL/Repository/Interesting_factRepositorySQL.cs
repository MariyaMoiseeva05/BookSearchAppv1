using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Interesting_factRepositorySQL : IRepository<Interesting_fact>
    {
        private BookSearchContext db;
        public Interesting_factRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(Interesting_fact Interesting_fact)
        {
            db.Interesting_Facts.Add(Interesting_fact);
            db.SaveChanges();
            return Interesting_fact.FactId;
        }

        public void Delete(object id)
        {
            Interesting_fact Interesting_fact = db.Interesting_Facts.Find((int)id);
            if (Interesting_fact != null)
                db.Interesting_Facts.Remove(Interesting_fact);
        }

        public Interesting_fact GetItem(object id)
        {
            return db.Interesting_Facts.Find((int)id);
        }

        public IEnumerable<Interesting_fact> GetAll()
        {
            return db.Interesting_Facts.ToList();
        }

        public void Update(Interesting_fact Interesting_fact, object factId)
        {
            var fi = db.Interesting_Facts.Find((int)factId);
            fi.AuthorID = Interesting_fact.AuthorID;
            fi.Content = Interesting_fact.Content;
            fi.Author = Interesting_fact.Author;
            fi.ImagePath = Interesting_fact.ImagePath;
            fi.ImageLink = Interesting_fact.ImageLink;

            db.Interesting_Facts.Update(fi);
            db.SaveChanges();
        }
    }
}

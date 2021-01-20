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
        public void Create(Interesting_fact Interesting_fact)
        {
            db.Interesting_Facts.Add(Interesting_fact);
        }

        public void Delete(int? id)
        {
            Interesting_fact Interesting_fact = db.Interesting_Facts.Find(id);
            if (Interesting_fact != null)
                db.Interesting_Facts.Remove(Interesting_fact);
        }

        public Interesting_fact GetItem(int? id)
        {
            return db.Interesting_Facts.Find(id);
        }

        public IEnumerable<Interesting_fact> GetAll()
        {
            return db.Interesting_Facts.ToList();
        }

        public void Update(Interesting_fact Interesting_fact, int? factId)
        {
            var fi = db.Interesting_Facts.Find(factId);
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

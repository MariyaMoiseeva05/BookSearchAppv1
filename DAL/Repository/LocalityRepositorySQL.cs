using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class LocalityRepositorySQL : IRepository <Locality>
    {
        private BookSearchContext db;
        public LocalityRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Locality Locality)
        {
            db.Localities.Add(Locality);
            db.SaveChanges();
        }
        public void Delete(object localityId)
        {
            var locality = db.Localities.FirstOrDefault(x => x.LocalityId == (int)localityId);

            if (locality != null)
            {
                db.Localities.Remove(locality);
                db.SaveChanges();
            }
        }

        public Locality GetItem(object id)
        {
            return db.Localities
                .Include(a => a.Adverts)
                .First(b => b.LocalityId == (int)id);
        }

        public IEnumerable<Locality> GetAll()
        {
            return db.Localities.ToList();
        }

        public void Update(Locality Locality, object localityId)
        {
            var locality = db.Localities.Find((int)localityId);

            locality.Type = Locality.Type;
            locality.Name = Locality.Name;
            locality.Timezone = Locality.Timezone;
            locality.Adverts = Locality.Adverts;

            db.Localities.Update(locality);
            db.SaveChanges();
        }
    }
}

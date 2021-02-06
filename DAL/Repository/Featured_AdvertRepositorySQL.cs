using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace DAL.Repository
{
    public class Featured_AdvertRepositorySQL : IRepository<Featured_Advert>
    {
        private BookSearchContext db;
        public Featured_AdvertRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Featured_Advert Featured_Advert)
        {
            db.Featured_Adverts.Add(Featured_Advert);
            db.SaveChanges();
        }

        public void Delete(object featadvertId)
        {
            var featadvert = db.Featured_Adverts.FirstOrDefault(x => x.Featured_AdvertId == (int)featadvertId);

            if (featadvert != null)
            {
                db.Featured_Adverts.Remove(featadvert);
                db.SaveChanges();
            }
        }

        public Featured_Advert GetItem(object id)
        {
            return db.Featured_Adverts.Find((int)id);
        }

        public IEnumerable<Featured_Advert> GetAll()
        {
            return db.Featured_Adverts.ToList();
        }

        public void Update(Featured_Advert Featured_Advert, object featadvertId)
        {
            var featadvert = db.Featured_Adverts.Find((int)featadvertId);

            featadvert.UserId = Featured_Advert.UserId;
            featadvert.AdvertId = Featured_Advert.AdvertId;

            db.Featured_Adverts.Update(featadvert);
            db.SaveChanges();
        }
    }
}

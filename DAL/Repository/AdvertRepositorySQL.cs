using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class AdvertRepositorySQL : IRepository<Advert>
    {
        private BookSearchContext db;
        public AdvertRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Advert Advert)
        {
            db.Adverts.Add(Advert);
            db.SaveChanges();
        }

        public void Delete(object advertId)
        {
            var advert = db.Adverts.FirstOrDefault(x => x.AdvertID == (string)advertId);

            if (advert != null)
            {
                db.Adverts.Remove(advert);
                db.SaveChanges();
            }

        }

        public Advert GetItem(object id)
        {
            return db.Adverts
                .Include(m => m.Message)
                .First(b => b.AdvertID == (string)id);

        }

        public IEnumerable<Advert> GetAll()
        {
            return db.Adverts
                .Include(m => m.Message)
                .ToList();
        }

        public void Update(Advert Advert, object advertId)
        {
            var advert = db.Adverts.Find((string)advertId);
            advert.Content = Advert.Content;
            advert.LocalityId = Advert.LocalityId;
            advert.ExchangeCompleted = Advert.ExchangeCompleted;
            advert.SaleCompleted = Advert.SaleCompleted;
            advert.Finish = Advert.Finish;
            advert.Date_of_Create = Advert.Date_of_Create;
            advert.Number_of_views = Advert.Number_of_views;
            advert.Delivery = Advert.Delivery;
            advert.Pickup = Advert.Pickup;
            advert.Message = Advert.Message;
            advert.Featured_Adverts = Advert.Featured_Adverts;
            advert.Like_Adverts = Advert.Like_Adverts;
            advert.BookId = Advert.BookId;
            advert.UserId = Advert.UserId;

            db.Adverts.Update(advert);
            db.SaveChanges();
        }
        
    }
}

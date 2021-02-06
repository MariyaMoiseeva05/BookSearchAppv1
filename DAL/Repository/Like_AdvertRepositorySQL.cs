using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Like_AdvertRepositorySQL : IRepository <Like_Advert>
    {
        private BookSearchContext db;
        public Like_AdvertRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Like_Advert Like_Advert)
        {
            db.Like_Adverts.Add(Like_Advert);
            db.SaveChanges();
        }

        public void Delete(object likeId)
        {
            var like = db.Like_Adverts.FirstOrDefault(x => x.Like_AdvertId == (int)likeId);

            if (like != null)
            {
                db.Like_Adverts.Remove(like);
                db.SaveChanges();
            }
        }

        public Like_Advert GetItem(object id)
        {
            return db.Like_Adverts.Find((int)id);
        }

        public IEnumerable<Like_Advert> GetAll()
        {
            return db.Like_Adverts.ToList();
        }

        public void Update(Like_Advert Like_Advert, object likeId)
        {
            var like = db.Like_Adverts.Find((int)likeId);

            like.UserId = Like_Advert.UserId;
            like.AdvertId = Like_Advert.AdvertId;

            db.Like_Adverts.Update(like);
            db.SaveChanges();
        }
    }
}

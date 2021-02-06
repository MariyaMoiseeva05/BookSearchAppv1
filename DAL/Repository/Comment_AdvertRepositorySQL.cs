using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Comment_AdvertRepositorySQL : IRepository<Comment_Advert>
    {
        private BookSearchContext db;
        public Comment_AdvertRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Comment_Advert Comment_Advert)
        {
            db.Comment_Adverts.Add(Comment_Advert);
            db.SaveChanges();
        }

        public void Delete(object commentId)
        {
            var comment = db.Comment_Adverts.FirstOrDefault(x => x.Comment_AdvertId == (int)commentId);

            if (comment != null)
            {
                db.Comment_Adverts.Remove(comment);
                db.SaveChanges();
            }
        }

        public Comment_Advert GetItem(object id)
        {
            return db.Comment_Adverts.Find((int)id);
        }

        public IEnumerable<Comment_Advert> GetAll()
        {
            return db.Comment_Adverts.ToList();
        }

        public void Update(Comment_Advert Comment_Advert, object commentId)
        {
            var comment = db.Comment_Adverts.Find((int)commentId);

            comment.Content = Comment_Advert.Content;
            comment.UserId = Comment_Advert.UserId;
            comment.AdvertId = Comment_Advert.AdvertId;

            db.Comment_Adverts.Update(comment);
            db.SaveChanges();
        }


    }
}

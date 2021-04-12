using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class UserRepositorySQL : IRepository<User>
    {
        private BookSearchContext db;
        public UserRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(User User)
        {
            db.PUsers.Add(User);
            db.SaveChanges();

        }

        public void Delete(object userId)
        {
            var user = db.PUsers.FirstOrDefault(x => x.UserId == (string)userId);

            if (user != null)
            {
                db.PUsers.Remove(user);
                db.SaveChanges();
            }
        }

        public User GetItem(object id)
        {
            return db.Users
                .Include(a => a.Advert)
                .Include(m => m.Message)
                .Include(fa => fa.Featured_Adverts)
                .Include(fb => fb.Featured_Books)
                .Include(a => a.Think)
                .Include(r => r.Review)
                .Include(q => q.Quote)
                .First (u => u.UserId == (string)id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.PUsers
                .Include(a => a.Advert)
                .Include(m => m.Message)
                .Include(fa => fa.Featured_Adverts)
                .Include(fb => fb.Featured_Books)
                .Include(a => a.Think)
                .Include(r => r.Review)
                .Include(q => q.Quote)
                .ToList();
        }

        public void Update(User User, object userId)
        {
            var user = db.PUsers.Find((string)userId);
            user.Review = User.Review;
            user.Quote = User.Quote;
            user.Think = User.Think;
            user.Email = User.Email;
            user.Login = User.Login;
            user.Name = User.Name;
            user.Surname = User.Surname;
            user.Sex = User.Sex;
            user.Interest = User.Interest;
            user.Favorite_books = User.Favorite_books;
            user.Country = User.Country;
            user.Place = User.Place;
            user.About_me = User.About_me;
            user.Date_of_Birth = User.Date_of_Birth;
            user.ImageLink = User.ImageLink;
            user.ImagePath = User.ImagePath;
            user.Advert = User.Advert;
            user.Message = User.Message;
            user.Featured_Books = User.Featured_Books;
            user.Featured_Adverts = User.Featured_Adverts;

            db.PUsers.Update(User);
            db.SaveChanges();
        }

    }
}
    
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

        public void Delete(int? userId)
        {
            var user = db.PUsers.FirstOrDefault(x => x.UserId == userId);

            if (user != null)
            {
                db.PUsers.Remove(user);
                db.SaveChanges();
            }
        }

        public User GetItem(int? id)
        {
            return db.Users
                .Include(c => c.Comment)
                .Include(a => a.Think)
                .Include(r => r.Review)
                .Include(q => q.Quote)
                .First (u => u.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.PUsers
                 .Include(c => c.Comment)
                .Include(a => a.Think)
                .Include(r => r.Review)
                .Include(q => q.Quote)
                .ToList();
        }

        public void Update(User User, int? userId)
        {
            var user = db.PUsers.Find(userId);
            user.Comment = User.Comment;
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

            db.PUsers.Update(User);
            db.SaveChanges();

        }
    }
}
    
﻿using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ReviewRepositorySQL : IRepository<Review>
    {
        private BookSearchContext db;
        public ReviewRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(Review Review)
        {
            db.Reviews.Add(Review);
            db.SaveChanges();
            return Review.RewiewId;
        }

        public void Delete(object id)
        {
            Review Review = db.Reviews.Find((int)id);
            if (Review != null)
                db.Reviews.Remove(Review);
        }

        public Review GetItem(object id)
        {
            return db.Reviews
               .Include(b => b.Book).ThenInclude(a => a.Authors).ThenInclude(av => av.Author)
                .Include(b => b.Book).ThenInclude(g => g.Genres_Books).ThenInclude(ge => ge.Genre)
               .Include(u => u.User)
               .SingleOrDefault(r => r.RewiewId == (int)id);
        }

        public IEnumerable<Review> GetAll()
        {
            return db.Reviews
                 .Include(b => b.Book).ThenInclude(a => a.Authors).ThenInclude(av => av.Author)
                 .Include(u => u.User)
                 .ToList();
        }

        public void Update(Review Review, object reviewId)
        {
            var rw = db.Reviews.Find((int)reviewId);

            rw.Title = Review.Title;
            rw.Text = Review.Text;
            rw.Type = Review.Type;
            rw.BookID = Review.BookID;
            rw.UserID = Review.UserID;
            rw.Book = Review.Book;
            rw.Rating = Review.Rating;
            rw.Comments = Review.Comments;

            db.Reviews.Update(rw);
            db.SaveChanges();
        }
    }
}

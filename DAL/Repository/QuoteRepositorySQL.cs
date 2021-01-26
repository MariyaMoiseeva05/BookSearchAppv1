﻿using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class QuoteRepositorySQL : IRepository<Quote>
    {
        private BookSearchContext db;
        public QuoteRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Quote Quote)
        {
            db.Quotes.Add(Quote);
        }

        public void Delete(object id)
        {
            Quote Quote = db.Quotes.Find((int)id);
            if (Quote != null)
                db.Quotes.Remove(Quote);
        }

        public Quote GetItem(object id)
        {
            return db.Quotes.Find((int)id);
        }

        public IEnumerable<Quote> GetAll()
        {
            return db.Quotes.ToList();
        }

        public void Update(Quote Quote, object quoteId)
        {
            var qt = db.Quotes.Find((int)quoteId);

            qt.BookID = Quote.BookID;
            qt.Content = Quote.Content;
            qt.Book = Quote.Book;

            db.Quotes.Update(qt);
            db.SaveChanges();

        }
    }
}

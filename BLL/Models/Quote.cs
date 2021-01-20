using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class QuoteModel
    {
        public int QuoteId { get; set; }
        public int? BookID { get; set; }
        public string Content { get; set; }
        public virtual Book Book { get; set; }
        public QuoteModel() { }
        public QuoteModel(Quote q)
        {
            QuoteId = q.QuoteId;
            BookID = q.BookID;
            Content = q.Content;
            Book = q.Book;

        }
    }
}

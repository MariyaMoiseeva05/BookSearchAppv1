using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Featured_BookModel
    {
        public int Featured_BookId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public Featured_BookModel() { }
        public Featured_BookModel(Featured_Book fb) {

            Featured_BookId = fb.Featured_BookId;
            UserId = fb.UserId;
            User = fb.User;
            BookId = fb.BookId;
            Book = fb.Book;
        }
    }
}

using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string UserId { get; set; }
        public int BookID { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime Date_of_creation { get; set; }
        public virtual Book Book { get; set; } // навигационное свойство
        public virtual User User { get; set; }
        public CommentModel() { }
        public CommentModel(Comment c)
        {
            CommentId = c.CommentId;
            User = c.User;
            UserId = c.UserId;
            BookID = c.BookID;
            Content = c.Content;
            Date_of_creation = c.Date_of_creation;
            Book = c.Book;
            Rating = c.Rating;

        }


    }
}

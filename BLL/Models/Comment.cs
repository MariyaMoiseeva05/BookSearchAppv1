using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string? UserId { get; set; }
        public int? BookID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public DateTime Date_of_creation { get; set; }
        public virtual Book Book { get; set; } // навигационное свойство
        public virtual User User { get; set; }
        public virtual News News { get; set; }
        public virtual Review Review { get; set; }
        public CommentModel() { }
        public CommentModel(Comment c)
        {
            CommentId = c.CommentId;
            User = c.User;
            UserId = c.UserId;
            BookID = c.BookID;
            Content = c.Content;
            Title = c.Title;
            Date_of_creation = c.Date_of_creation;
            Book = c.Book;
            News = c.News;
            Review = c.Review;
            Rating = c.Rating;

        }


    }
}

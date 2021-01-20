using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        //public int? UserId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public DateTime Date_of_creation { get; set; }
        public virtual Book Book { get; set; } // навигационное свойство
        public CommentModel() { }
        public CommentModel(Comment c)
        {
            CommentId = c.CommentId;
            //UserId = c.UserId;
            Content = c.Content;
            Title = c.Title;
            Date_of_creation = c.Date_of_creation;
            Book = c.Book;
            Rating = c.Rating;

        }


    }
}

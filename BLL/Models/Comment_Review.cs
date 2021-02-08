using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Comment_ReviewModel
    {
        public int Comment_ReviewId { get; set; }
        public string UserId { get; set; }

        public int ReviewId { get; set; }
        public string Content { get; set; }
        public DateTime Date_of_creation { get; set; }
        public virtual Review Review { get; set; }
        public virtual User User { get; set; }
        public Comment_ReviewModel() { }
        public Comment_ReviewModel(Comment_Review cr) {
            Comment_ReviewId = cr.Comment_ReviewId;
            User = cr.User;
            UserId = cr.UserId;
            Review = cr.Review;
            ReviewId = cr.ReviewId;
            Content = cr.Content;
            Date_of_creation = cr.Date_of_creation;
        }
    }
}

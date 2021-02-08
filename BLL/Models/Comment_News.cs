using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Comment_NewsModel
    {
        public int Comment_NewsId { get; set; }
        public string UserId { get; set; } 
        public int NewsId { get; set; } 
        public string Content { get; set; }
        public DateTime Date_of_creation { get; set; }
        public virtual News News { get; set; }
        public virtual User User { get; set; }
        public Comment_NewsModel() { }
        public Comment_NewsModel(Comment_News cn) {

            Comment_NewsId = cn.Comment_NewsId;
            User = cn.User;
            UserId = cn.UserId;
            News = cn.News;
            NewsId = cn.NewsId;
            Content = cn.Content;
            Date_of_creation = cn.Date_of_creation;
        }
    }
}

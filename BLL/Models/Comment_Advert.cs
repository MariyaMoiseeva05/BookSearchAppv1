using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Comment_AdvertModel
    {
        public int Comment_AdvertId { get; set; }
        public string Content { get; set; }
        public DateTime Date_of_AddComment { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string AdvertId { get; set; }
        public Advert Advert { get; set; }

        public Comment_AdvertModel() { }
        public Comment_AdvertModel(Comment_Advert ca) {

            Comment_AdvertId = ca.Comment_AdvertId;
            Content = ca.Content;
            Date_of_AddComment = ca.Date_of_AddComment;
            UserId = ca.UserId;
            User = ca.User;
            Advert = ca.Advert;
            AdvertId = ca.AdvertId;
        }

    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Like_AdvertModel
    {
        public int Like_AdvertId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string AdvertId { get; set; }
        public Advert Advert { get; set; }

        public Like_AdvertModel() { }
        public Like_AdvertModel(Like_Advert la) {

            Like_AdvertId = la.Like_AdvertId;
            UserId = la.UserId;
            User = la.User;
            AdvertId = la.AdvertId;
            Advert = la.Advert;
        }
    }
}

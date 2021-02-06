using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Featured_AdvertModel
    {
        public int Featured_AdvertId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string AdvertId { get; set; }
        public Advert Advert { get; set; }

        public Featured_AdvertModel() { }
        public Featured_AdvertModel(Featured_Advert fa) {

            Featured_AdvertId = fa.Featured_AdvertId;
            User = fa.User;
            UserId = fa.UserId;
            Advert = fa.Advert;
            AdvertId = fa.AdvertId;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Featured_Advert // Таблица избранных объявлений
    {
        [Key]
        public int Featured_AdvertId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string AdvertId { get; set; }
        public Advert Advert { get; set; }

    }
}

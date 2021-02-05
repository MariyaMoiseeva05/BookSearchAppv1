using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Like_Advert
    {
        [Key]
        public int Like_AdvertId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string AdvertId { get; set; }
        public Advert Advert { get; set; }
    }
}

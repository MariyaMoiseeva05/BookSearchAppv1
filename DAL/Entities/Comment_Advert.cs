using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Comment_Advert
    {
        [Key]
        public int Comment_AdvertId { get; set; }
        public string Content { get; set; } // текст комментария
        [Display(Name = "Время добавления")]
        public DateTime Date_of_AddComment { get; set; } // Дата добавления комментария
        public string UserId { get; set; } // ссылка на пользователя
        public User User { get; set; }

        public string AdvertId { get; set; } // ссылка на объявление
        public Advert Advert { get; set; }
    }
}

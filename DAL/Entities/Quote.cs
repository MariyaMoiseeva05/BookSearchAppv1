using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Quote // Цитата из книги
    {
        [Key]
        public int QuoteId { get; set; }
        [Required()]
        public int BookID { get; set; } // внешний ключ
        public string UserID { get; set; }
        public int Like { get; set; } // (лайки, понравившиеся цитаты)скольким пользователям понравилась цитата
        public string Content { get; set; } // содержание отзыва
        public virtual Book Book { get; set; } // навигационное свойство
        public virtual User User { get; set; }

    }
}

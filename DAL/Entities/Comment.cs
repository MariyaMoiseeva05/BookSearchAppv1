using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required()]
        public string UserId { get; set; } // внешний ключ
        public int? BookID { get; set; } // внешний ключ

        [Display(Name = "Отзыв")]
        public string Content { get; set; } // содержание отзыва

        [Display(Name = "Название отзыва")]
        public string Title { get; set; } //  название 

        [Display(Name = "Оценка книги")]
        public int Rating { get; set; } //рейтинг книги

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата создания")]
        public DateTime Date_of_creation { get; set; } // дата создания

        public virtual Book Book { get; set; } // навигационное свойство
        public virtual News News { get; set; }
        public virtual Review Review { get; set; }
        public virtual User User { get; set; } 
    }
}

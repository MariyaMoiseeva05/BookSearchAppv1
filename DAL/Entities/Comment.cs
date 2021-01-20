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
       // public int? UserId { get; set; } // внешний ключ
        public int? BookID { get; set; } // внешний ключ
        public string Content { get; set; } // содержание отзыва
        public string Title { get; set; } //  название 
        public double Rating { get; set; } //рейтинг книги

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_creation { get; set; } // дата создания

        public virtual Book Book { get; set; } // навигационное свойство
        
    }
}

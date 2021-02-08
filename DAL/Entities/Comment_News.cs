using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Comment_News // Комментарий к новости
    {

        [Key]
        public int Comment_NewsId { get; set; }

        [Required()]
        public string UserId { get; set; } // внешний ключ
        public int NewsId { get; set; } // внешний ключ
        [Display(Name = "Комментарий")]
        public string Content { get; set; } // содержание комментария

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата создания")]
        public DateTime Date_of_creation { get; set; } // дата создания
        public virtual News News { get; set; }
        public virtual User User { get; set; }
    }
}

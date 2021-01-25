using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Think
    {
        [Key]
        public int ThinkId { get; set; }

        [Required()]
        public int? UserId { get; set; } //внешний ключ 
        [Display(Name = "Содержание")]
        public string Content { get; set; }

        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Дата создания")]
        public string Date_of_creation { get; set; }
        public virtual User User { get; set; }
    }
}

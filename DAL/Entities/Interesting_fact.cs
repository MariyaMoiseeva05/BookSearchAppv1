using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Interesting_fact
    {
        [Key]
        public int FactId { get; set; } // Id
        public int? AuthorID { get; set; }// Автор
        [Required]
        [Display(Name = "Интересный факт")]
        public string Content { get; set; }// Содержание
        public string ImageLink { get; set; }
        public string ImagePath { get; set; }
        public virtual Author Author { get; set; } // навигационное свойство
    }
}

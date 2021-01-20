using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class News
    {
        [Key]
        public int NewsId { get; set; } //Id
        [Required]
        [Display(Name = "Тема")]
        public string Topic { get; set; }// Тема
        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; } //Название
        public string ImageLink { get; set; }
        public string ImagePath{ get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата создания")]
        public DateTime Date_of_creation { get; set; } // Дата создания
        [Display(Name = "Содержание")]
        public string Content { get; set; } // Содержание
        public virtual ICollection<News_Tags> Tags { get; set; } = new HashSet<News_Tags>();

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Book
    {
        public Book()
        {
            Comment = new HashSet<Comment>();
            Review = new HashSet<Review>();
            Quote = new HashSet<Quote>();
        }

        [Key]
        public int? BookID { get; set; }
        [Required]
        public int? AuthorID { get; set; }
        [Required]
        [Display(Name = "Название книги")]
        public string Title { get; set; } // Название книги
        [Display(Name = "Описание")]
        public string Description { get; set; } // Описание
        [Display(Name = "Сюжет")]
        public string Story { get; set; } // Сюжет
        [Display(Name = "Тираж")]
        public string Edition { get; set; } // Тираж

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата выхода в свет")]
        public DateTime Publication_date { get; set; } // Дата выхода в свет
        //[Required()]
        public string ImagePath { get; set; } //Путь до изображения
        public string ImageLink { get; set; } // Ссылка на изображение
        [Display(Name = "Экранизации")]
        public string Screenings { get; set; }

        public virtual Author Author { get; set; } // навигационное свойство
        public virtual ICollection<Comment> Comment { get; set; }  // Отзывы
        public virtual ICollection<Quote> Quote { get; set; }  // Цитаты
        public virtual ICollection<Review> Review { get; set; } // Рецензии
        public ICollection<TypeOfLit_Book> Type_of_literature { get; set; } //тип литературы
        public virtual ICollection<Genre_Book> Genre_Books { get; set; }// Жанр книги


    }
}



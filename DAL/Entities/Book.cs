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
            Reviews = new HashSet<Review>();
            Quotes = new HashSet<Quote>();
            Adverts = new HashSet<Advert>();
        }

        [Key]
        public int BookID { get; set; }

        [Required]
        [Display(Name = "Название книги")]
        public string Title { get; set; } // Название книги

        [Display(Name = "Описание")]
        public string Description { get; set; } // Описание

        [Display(Name = "Сюжет")]
        public string Story { get; set; } // Сюжет

        [Display(Name = "Тираж")]
        public string Edition { get; set; } // Тираж

        [Display(Name = "Дата выхода в свет")]
        public string Publication_date { get; set; } // Дата выхода в свет
        //[Required()]
        public string ImagePath { get; set; } //Путь до изображения - хранить в блоб-полях
        public string ImageLink { get; set; } // Ссылка на изображение
        [Display(Name = "Экранизации")]
        public string Screenings { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }  // Цитаты
        public virtual ICollection<Review> Reviews { get; set; } // Рецензии
        public virtual ICollection<TypeOfLit_Book> Types_of_literature { get; set; }
        public virtual ICollection<Genre_Book> Genres_Books { get; set; }
        public virtual ICollection<Book_Collection> Book_Collections { get; set; }
        public virtual ICollection<Book_Character> Book_Characters { get; set; }
        public virtual ICollection<Author_Book> Authors { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }
        public virtual ICollection<Featured_Book> Featured_Books { get; set; } // Избранные книги


    }
}



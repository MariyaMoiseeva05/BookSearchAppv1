using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
            Interesting_fact = new HashSet<Interesting_fact>();
        }

        [Key]
        public int AuthorId { get; set; } //Id
        [Required()]
        public string Full_name { get; set; } // Ф.И.О.
        public string Pseudonym { get; set; } // Псевдоним

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Birth { get; set; } // Дата рождения

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Death { get; set; } // Дата смерти

        public string Place_of_Birth { get; set; } // Место рождения
        public string Place_of_Death { get; set; } // Место смерти
        public string Citizenship { get; set; } // Гражданство
        public string Occupation { get; set; } // Род деятельности
        public string Years_of_creativity { get; set; } // Годы творчества

        public string Language_of_works { get; set; } //Язык произвдений
        public string Debut { get; set; } // Дебют 
        public string Prizes { get; set; }// Премии 
        public string Awards { get; set; } // Награды
        public string Details { get; set; } // Подробно
        public string ImagePath { get; set; }
        public string ImageLink { get; set; }

        public virtual ICollection<Genre_Author> Genre { get; set; }// Жанр произведений
        public virtual ICollection<Book> Book { get; set; }  // Книга
        public virtual ICollection<Interesting_fact> Interesting_fact { get; set; }  // Интересные факты

    }
}

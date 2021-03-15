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
            Interesting_fact = new HashSet<Interesting_fact>();
            //Books = new HashSet<Book>();
        }

        [Key]
        public int AuthorId { get; set; } //Id
        [Required()]
        [Display(Name = "Автор")]
        public string Full_name { get; set; } // Ф.И.О.
        [Display(Name = "Псевдоним")]
        public string Pseudonym { get; set; } // Псевдоним

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Birth { get; set; } // Дата рождения

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата смерти")]
        public DateTime? Date_of_Death { get; set; } // Дата смерти

        [Display(Name = "Место рождения")]
        public string Place_of_Birth { get; set; } // Место рождения

        [Display(Name = "Место смерти")]
        public string Place_of_Death { get; set; } // Место смерти

        [Display(Name = "Гражданство")]
        public string Citizenship { get; set; } // Гражданство

        [Display(Name = "Род деятельности")]
        public string Occupation { get; set; } // Род деятельности

        [Display(Name = "Годы творчества")]
        public string Years_of_creativity { get; set; } // Годы творчества

        [Display(Name = "Язык произведений")]
        public string Language_of_works { get; set; } //Язык произвдений

        [Display(Name = "Дебют")]
        public string Debut { get; set; } // Дебют 

        [Display(Name = "Премии")]
        public string Prizes { get; set; }// Премии 

        [Display(Name = "Награды")]
        public string Awards { get; set; } // Награды

        [Display(Name = "Биография")]
        public string Details { get; set; } // Подробно
        public string ImagePath { get; set; }
        public string ImageLink { get; set; }
        public virtual ICollection<Author_Book> Book { get; set; }
       // public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Interesting_fact> Interesting_fact { get; set; }  // Интересные факты

    }
}

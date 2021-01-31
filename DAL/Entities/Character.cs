using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Character
    {
        [Key]
        public int CharacterId { get; set; } //Id

        [Required()]
        [Display(Name = "Имя персонажа")]
        public string Name { get; set; } // Имя персонажа

        [Display(Name = "Другие имена")]
        public string Other_name { get; set; } // Другие именя

        [Display(Name = "Пол")]
        public string Sex { get; set; } //Пол

        [Display(Name = "Вид / Раса")]
        public string View { get; set; } // Вид (Раса)

        [Display(Name = "Биография")]
        public string Biography { get; set; } // Биография

        [Display(Name = "Внешний вид")]
        public string Appearance { get; set; } // Внешний вид

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Birth { get; set; } // Дата рождения

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата смерти")]
        public DateTime Date_of_Death { get; set; } // Дата смерти

        public string ImagePath { get; set; }
        public string ImageLink { get; set; }
        public virtual ICollection<Book_Character> Book_Characters { get; set; }

    }
}

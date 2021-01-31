using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class CharacterModel
    {

        public int CharacterId { get; set; } //Id
        public string Name { get; set; } // Имя персонажа
        public string Other_name { get; set; } // Другие имена
        public string Sex { get; set; } //Пол
        public string View { get; set; } // Вид (Раса)
        public string Biography { get; set; } // Биография
        public string Appearance { get; set; } // Внешний вид
        public DateTime Date_of_Birth { get; set; } // Дата рождения
        public DateTime Date_of_Death { get; set; } // Дата смерти
        public string ImagePath { get; set; }
        public string ImageLink { get; set; }
        public virtual ICollection<Book_Character> Book_Characters { get; set; }

        public CharacterModel() { }
        public CharacterModel(Character ch)
        {
            CharacterId = ch.CharacterId;
            Name = ch.Name;
            Other_name = ch.Other_name;
            Sex = ch.Sex;
            View = ch.View;
            Biography = ch.Biography;
            Appearance = ch.Appearance;
            Date_of_Birth = ch.Date_of_Birth;
            Date_of_Death = ch.Date_of_Death;
            ImagePath = ch.ImagePath;
            ImageLink = ch.ImageLink;
            Book_Characters = Book_Characters;

        }
    }
}

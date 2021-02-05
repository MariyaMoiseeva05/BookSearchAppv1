﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Comment_Advert = new HashSet<Comment_Advert>();
            Review = new HashSet<Review>();
            Quote = new HashSet<Quote>();
            Think = new HashSet<Think>();
            Message = new HashSet<Message>();
            Advert = new HashSet<Advert>();
        }

        [Key]
        public string UserId { get; set; } //Id

        [Required()]
        [Display(Name = "Имя пользователя")]
        public string Login { get; set; } //Имя пользователя

        [Display(Name = "Имя")]
        public string Name { get; set; } //Имя

        [Display(Name = "Фамилия")]
        public string Surname { get; set; } //Фамилия

        [Display(Name = "Пол")]
        public bool Sex { get; set; } //Пол

        [Display(Name = "Интересы")]
        public string Interest { get; set; } // Увлечения

        [Display(Name = "Любимые книги")]
        public string Favorite_books { get; set; } // Любимые книги

        [Display(Name = "Страна проживания")]
        public string Country { get; set; } // Страна проживания

        [Display(Name = "Место жительства (Город, посёлок и т.д.)")]
        public string Place { get; set; } // Место жительства

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Birth { get; set; } // Дата рождения

        [Display(Name = "О себе")]
        public string About_me { get; set; } // О себе
        public string ImagePath { get; set; } //Путь до изображения
        public string ImageLink { get; set; } // Фотка

        public virtual ICollection<Comment> Comment { get; set; }  // Отзывы
        public virtual ICollection<Think> Think { get; set; }  // Мысли
        public virtual ICollection<Quote> Quote { get; set; }  // Цитаты
        public virtual ICollection<Review> Review { get; set; } // Рецензии
        public virtual ICollection<Message> Message { get; set; } // Сообщения
        public virtual ICollection<Advert> Advert { get; set; } // Объявления
        public virtual ICollection<Comment_Advert> Comment_Advert { get; set; } // Комментарии объявления
        public virtual ICollection<Featured_Advert> Featured_Adverts { get; set; } // Избранные объявления
        public virtual ICollection<Like_Advert> Like_Adverts { get; set; } // Лайки на объявлениях
    }
}

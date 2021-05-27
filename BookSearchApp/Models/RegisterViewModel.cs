using System;
using System.ComponentModel.DataAnnotations;

namespace BookSearchApp.Models
{
    public class RegisterViewModel // класс, который представляет данные для регистрации пользователя 
    {
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан Логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Display(Name = "Пол")]
        public bool Sex { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

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
    }
}

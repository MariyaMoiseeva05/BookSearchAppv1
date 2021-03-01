using System.ComponentModel.DataAnnotations;

namespace BookSearchApp.Models
{
    public class LoginViewModel // класс, который описывает модель данных для входа пользователя
    {
        [Required(ErrorMessage = "Не указан логин")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

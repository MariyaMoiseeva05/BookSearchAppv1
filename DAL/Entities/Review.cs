using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Review // рецензия на книгу
    {
        [Key]
        public int RewiewId { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 50, ErrorMessage = "Попробуйте написать рецензию ещё раз, чтобы она была длиннее, У Вас всё получится!")]
        [Display(Name = "Текст рецензии")]
        public string Text { get; set; }

        [Display(Name = "Тип")]
        public bool Type { get; set; } // положительная или отрицательная

        [Display(Name = "Рейтинг книги")]
        public double Rating { get; set; } //рейтинг книги
        public int? BookID { get; set; }
        public int? UserID { get; set; }
        public virtual Book Book { get; set; } // навигационное свойство
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}

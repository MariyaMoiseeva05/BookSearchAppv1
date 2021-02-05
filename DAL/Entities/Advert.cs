using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Advert // Объявления
    {
        public Advert()
        {
            Message = new HashSet<Message>();
            Comment_Advert = new HashSet<Comment_Advert>();
        }
        [Key]
        public string AdvertID { get; set; }
        public string Content { get; set; } // текст
        [Required()]
        public int LocalityId { get; set; } // ссылка на населённый пункт
        public virtual Locality Locality { get; set; }
        public bool ExchangeCompleted { get; set; } // Флаг, который определяет, обменена книга или нет
        public bool SaleCompleted { get; set; } // Флаг, который определяет, продана книга  или нет 
        public bool Finish { get; set; } // Флаг того, что обмен завершён
        [Display(Name = "Дата создания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_of_Create { get; set; } // Дата создания
        public int Number_of_views { get; set; } // Количество просмотров
        public bool Delivery { get; set; } // Флаг доставки
        public bool Pickup { get; set; } // Флаг самовывоза
        public virtual ICollection<Message> Message { get; set; } // Сообщения
        public virtual ICollection<Comment_Advert> Comment_Advert { get; set; } // Комментарии
        public virtual ICollection<Featured_Advert> Featured_Adverts { get; set; } // Избранные объявления
        public virtual ICollection<Like_Advert> Like_Adverts { get; set; } // Избранные объявления

        public int BookId { get; set; } // ссылка на книгу
        public virtual Book Book { get; set; }
        public string UserId { get; set; } // ссылка на пользователя
        public virtual User User { get; set; }

    }
}

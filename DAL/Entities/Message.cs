using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Message // Можно оставить только автора сообщения
    {
        [Key]
        public int MessageId { get; set; } // Id Сообщения
        public string Content { get; set; } // Текст сообщения
        [Required]
        public string Sender_Id { get; set; } // Id отправителя
        [Required]
        public string Recipient_Id { get; set; } // Id получателя
        public bool Readed { get; set; } // Флаг, который определяет, прочитано сообщение (1) или нет (0).
       
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Create_Message { get; set; } // Дата и время отправки сообщения
        public virtual User User { get; set; }// ссылка на пользователя
        public string AdvertId { get; set; } // ссылка на объявление
        public virtual Advert Advert { get; set; }
    }
}

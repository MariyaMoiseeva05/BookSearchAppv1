using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; } 
        public string Content { get; set; } 
        public string Sender_Id { get; set; } 
        public string Recipient_Id { get; set; } 
        public bool Readed { get; set; } 
        public DateTime Create_Message { get; set; }
        public virtual User User { get; set; }
        public string AdvertId { get; set; } 
        public virtual Advert Advert { get; set; }

        public MessageModel() { }
        public MessageModel(Message m) {
            MessageId = m.MessageId;
            Content = m.Content;
            Sender_Id = m.Sender_Id;
            Recipient_Id = m.Recipient_Id;
            Readed = m.Readed;
            Create_Message = m.Create_Message;
            User = m.User;
            Advert = m.Advert;
            AdvertId = m.AdvertId;
        }
    }
}

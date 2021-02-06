using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class MessageRepositorySQL : IRepository<Message>
    {
        private BookSearchContext db;
        public MessageRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Message Message)
        {
            db.Messages.Add(Message);
            db.SaveChanges();
        }
        public void Delete(object messageId)
        {
            var message = db.Messages.FirstOrDefault(x => x.MessageId == (int)messageId);

            if (message != null)
            {
                db.Messages.Remove(message);
                db.SaveChanges();
            }
        }

        public Message GetItem(object id)
        {
            return db.Messages.Find((int)id);
        }

        public IEnumerable<Message> GetAll()
        {
            return db.Messages.ToList();
        }

        public void Update(Message Messages, object messageId)
        {
            var message = db.Messages.Find((int)messageId);

            message.Content = Messages.Content;
            message.Sender_Id = Messages.Sender_Id;
            message.Recipient_Id = Messages.Recipient_Id;
            message.Readed = Messages.Readed;
            message.Create_Message = Messages.Create_Message;
            message.AdvertId = Messages.AdvertId;

            db.Messages.Update(message);
            db.SaveChanges();
        }

    }
}

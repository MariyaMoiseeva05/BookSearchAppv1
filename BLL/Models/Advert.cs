using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class AdvertModel
    {
        public string AdvertID { get; set; }
        public string Content { get; set; } 
        public int LocalityId { get; set; } 
        public virtual Locality Locality { get; set; }
        public bool ExchangeCompleted { get; set; } 
        public bool SaleCompleted { get; set; } 
        public bool Finish { get; set; } 
        public DateTime Date_of_Create { get; set; }
        public int Number_of_views { get; set; }
        public bool Delivery { get; set; }
        public bool Pickup { get; set; }
        public virtual ICollection<Message> Message { get; set; } 
        public virtual ICollection<Comment_Advert> Comment_Advert { get; set; }
        public virtual ICollection<Featured_Advert> Featured_Adverts { get; set; }
        public virtual ICollection<Like_Advert> Like_Adverts { get; set; }

        public int BookId { get; set; } 
        public virtual Book Book { get; set; }
        public string UserId { get; set; } 
        public virtual User User { get; set; }

        public AdvertModel() { }
        public AdvertModel(Advert a)
        {
            AdvertID = a.AdvertID;
            Content = a.Content;
            LocalityId = a.LocalityId;
            Locality = a.Locality;
            UserId = a.UserId;
            BookId = a.BookId;
            Book = a.Book;
            ExchangeCompleted = a.ExchangeCompleted;
            SaleCompleted = a.SaleCompleted;
            Finish = a.Finish;
            Date_of_Create = a.Date_of_Create;
            Number_of_views = a.Number_of_views;
            Delivery = a.Delivery;
            Pickup = a.Pickup;
            Message = a.Message;
            Comment_Advert = a.Comment_Advert;
            Featured_Adverts = a.Featured_Adverts;
            Like_Adverts = a.Like_Adverts;

        }

    }
}

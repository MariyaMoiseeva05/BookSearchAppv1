using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Sex { get; set; }
        public string Interest { get; set; }
        public string Favorite_books { get; set; }
        public string Country { get; set; }
        public string Place { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string About_me { get; set; }
        public string ImageLink { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Comment_Review> Comment_Review { get; set; }  // Комментарии к рецензиям
        public virtual ICollection<Comment_News> Comment_News { get; set; }  // Комментарии к новостям
        public virtual ICollection<Think> Think { get; set; }  // Мысли
        public virtual ICollection<Quote> Quote { get; set; }  // Цитаты
        public virtual ICollection<Review> Review { get; set; } // Рецензии
        public virtual ICollection<Message> Message { get; set; } // Сообщения
        public virtual ICollection<Advert> Advert { get; set; } // Объявления
        public virtual ICollection<Featured_Advert> Featured_Adverts { get; set; } // Избранные объявления
        public virtual ICollection<Like_Advert> Like_Adverts { get; set; } // Лайки на объявлениях
        public virtual ICollection<Featured_Book> Featured_Books { get; set; } // Избранные книги


        public UserModel() { }
        public UserModel(User u)
        {
            UserId = u.UserId;
            Login = u.Login;
            Name = u.Name;
            Surname = u.Surname;
            Sex = u.Sex;
            Interest = u.Interest;
            Favorite_books = u.Favorite_books;
            Country = u.Country;
            Place = u.Place;
            Date_of_Birth = u.Date_of_Birth;
            About_me = u.About_me;
            ImageLink = u.ImageLink;
            ImagePath = u.ImagePath;
            Think = u.Think;
            Review = u.Review;
            Quote = u.Quote;
            Comment_News = u.Comment_News;
            Comment_Review = u.Comment_Review;
            Message = u.Message;
            Advert = u.Advert;
            Featured_Adverts = u.Featured_Adverts;
            Like_Adverts = u.Like_Adverts;
            Featured_Books = u.Featured_Books;

        }

    }
}

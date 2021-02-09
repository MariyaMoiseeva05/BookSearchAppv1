using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class BookModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public string Edition { get; set; }
        public string Screenings { get; set; }
        public DateTime Publication_date { get; set; }
        public string ImageLink { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<DAL.Entities.TypeOfLit_Book> Type_of_literature { get; set; }
        public virtual ICollection<Quote> Quote { get; set; }  // Цитаты
        public virtual ICollection<Review> Review { get; set; } // Рецензии
        public virtual ICollection<Genre_Book> Genre_Books { get; set; }
        public virtual ICollection<Book_Collection> Book_Collections { get; set; }
        public virtual ICollection<Book_Character> Book_Characters { get; set; }
        public virtual ICollection<Author_Book> Author { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }
        public virtual ICollection<Featured_Book> Featured_Books { get; set; }
        public BookModel() { }
        public BookModel(Book b)
        {

            BookID = b.BookID;
            Title = b.Title;
            Description = b.Description;
            Story = b.Story;
            Edition = b.Edition;
            Publication_date = b.Publication_date;
            ImageLink = b.ImageLink;
            ImagePath = b.ImagePath;
            Author = b.Authors;
            Screenings = b.Screenings;
            Type_of_literature = b.Types_of_literature;
            Quote = b.Quotes;
            Review = b.Reviews;
            Genre_Books = b.Genres_Books;
            Book_Collections = b.Book_Collections;
            Book_Characters = b.Book_Characters;
            Adverts = b.Adverts;
            Featured_Books = b.Featured_Books;
        }

    }
}

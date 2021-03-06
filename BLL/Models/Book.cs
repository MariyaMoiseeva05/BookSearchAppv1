﻿using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class BookModel
    {
        public int? BookID { get; set; }
        public int? AuthorID { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Story { get; set; }
        public string Edition { get; set; }
        public string Screenings { get; set; }
        public DateTime Publication_date { get; set; }
        public string ImageLink { get; set; }
        public string ImagePath { get; set; }
        public ICollection<TypeOfLit_Book> Type_of_literature { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }  // Отзывы
        public virtual ICollection<Quote> Quote { get; set; }  // Цитаты
        public virtual ICollection<Review> Review { get; set; } // Рецензии
        public virtual ICollection<Genre_Book> Genre_Books { get; set; }
        public BookModel() { }
        public BookModel(Book b)
        {

            BookID = b.BookID;
            AuthorID = b.AuthorID;
            Title = b.Title;
            Description = b.Description;
            Story = b.Story;
            Edition = b.Edition;
            Publication_date = b.Publication_date;
            ImageLink = b.ImageLink;
            ImagePath = b.ImagePath;
            Comment = b.Comment;
            Author = b.Author;
            Screenings = b.Screenings;
            Type_of_literature = b.Type_of_literature;
            Quote = b.Quote;
            Review = b.Review;
            Genre_Books = b.Genre_Books;
        }

    }
}

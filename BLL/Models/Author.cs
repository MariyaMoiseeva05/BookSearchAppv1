﻿using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        public string Full_name { get; set; }
        public string Pseudonym { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public DateTime Date_of_Death { get; set; }
        public string Place_of_Birth { get; set; }
        public string Place_of_Death { get; set; }
        public string Citizenship { get; set; }
        public string Occupation { get; set; }
        public string Years_of_creativity { get; set; }
        public string Language_of_works { get; set; }
        public string Debut { get; set; }
        public string Prizes { get; set; }
        public string Awards { get; set; }
        public string Details { get; set; } // Подробно
        public string ImageLink { get; set; }
        public string ImagePath{ get; set; }
        public virtual ICollection<Book> Book { get; set; }  // Книга
        public virtual ICollection<Interesting_fact> Interesting_fact { get; set; }  // Интересные факты


        public AuthorModel() { }
        public AuthorModel(Author a)
        {

            AuthorId = a.AuthorId;
            Full_name = a.Full_name;
            Pseudonym = a.Pseudonym;
            Date_of_Birth = a.Date_of_Birth;
            Date_of_Death = a.Date_of_Death;
            Citizenship = a.Citizenship;
            Occupation = a.Occupation;
            Years_of_creativity = a.Years_of_creativity;
            Language_of_works = a.Language_of_works;
            Debut = a.Debut;
            Prizes = a.Prizes;
            Awards = a.Awards;
            ImageLink = a.ImageLink;
            ImagePath = a.ImagePath;
            Book = a.Book;
            Interesting_fact = a.Interesting_fact;
            Details = a.Details;
        }
    }
}


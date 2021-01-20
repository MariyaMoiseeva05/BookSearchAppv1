using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Genre_AuthorModel
    {
        public int AuthorId { get; set; }

        public int GenreId { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public Genre_AuthorModel() { }
        public Genre_AuthorModel(Genre_Author ga)
        {
            AuthorId = ga.AuthorId;
            GenreId = ga.GenreId;
            Author = ga.Author;
            Genre = ga.Genre;

        }
    }
}

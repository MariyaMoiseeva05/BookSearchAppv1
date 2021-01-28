using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class Interesting_factModel
    {
        public int FactId { get; set; }
        public int AuthorID { get; set; }
        public string Content { get; set; }
        public string ImageLink { get; set; }
        public string ImagePath { get; set; }
        public virtual Author Author { get; set; } // навигационное свойство
        public Interesting_factModel() { }
        public Interesting_factModel(Interesting_fact f)
        {
            FactId = f.FactId;
            AuthorID = f.AuthorID;
            Content = f.Content;
            Author = f.Author;
            ImagePath = f.ImagePath;
            ImageLink = f.ImageLink;

        }
    }
}

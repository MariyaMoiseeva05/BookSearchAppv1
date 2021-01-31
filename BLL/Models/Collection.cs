using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class CollectionModel
    {
        public int CollectionId { get; set; } //Id
        public string Title { get; set; } // Название коллекции книг
        public string Info { get; set; } // Подробная информация о коллекции
        public string ImagePath { get; set; }
        public string ImageLink { get; set; }
        public virtual ICollection<Book_Collection> Book_Collections { get; set; }
        public CollectionModel() { }
        public CollectionModel(Collection cl)
        {
            CollectionId = cl.CollectionId;
            Title = cl.Title;
            Info = cl.Info;
            ImagePath = cl.ImagePath;
            ImageLink = cl.ImageLink;
            Book_Collections = cl.Book_Collections;

        }
    }
}

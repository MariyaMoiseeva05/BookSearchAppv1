using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Collection
    {
        [Key]
        public int CollectionId { get; set; } //Id

        [Required()]
        [Display(Name = "Название коллекции книг")]
        public string Title { get; set; } // Название коллекции книг
        public string Info { get; set; } // Подробная информация о коллекции
        public string ImagePath { get; set; }
        public string ImageLink { get; set; }
        public virtual ICollection<Book_Collection> Book_Collections { get; set; }

    }
    
}

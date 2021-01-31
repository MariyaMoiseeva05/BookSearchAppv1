using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Genre
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        [Display(Name = "Жанр")]
        public string NameGenre { get; set; }
        public virtual ICollection<Genre_Book> Genre_Books { get; set; }
       
        
    }
}

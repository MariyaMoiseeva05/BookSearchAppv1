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
        public string NameGenre { get; set; }
        public ICollection<Genre_Book> Genre_Books { get; set; }
        
    }
}

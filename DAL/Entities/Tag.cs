using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Тэг")]
        public string Name { get; set; }

        public virtual ICollection<News_Tags> News { get; set; } = new HashSet<News_Tags>();
    }
}

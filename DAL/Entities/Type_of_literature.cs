using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Type_of_literature
    {
        [Key]
        public int Type_of_literatureId { get; set; }
        [Required]
        [Display(Name = "Тип литературы")]
        public string Name_Type { get; set; }
        public virtual ICollection<TypeOfLit_Book>Book { get; set; }


    }
}

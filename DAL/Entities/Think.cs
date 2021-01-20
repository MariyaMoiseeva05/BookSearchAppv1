using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public partial class Think
    {
        [Key]
        public int ThinkId { get; set; }

        [Required()]
       // public int? UserId { get; set; } //внешний ключ 
        public string Content { get; set; }
        public string Title { get; set; }
        public string Date_of_creation { get; set; }
    }
}

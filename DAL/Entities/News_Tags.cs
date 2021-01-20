using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class News_Tags
    {
        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}

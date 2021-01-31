using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
        public class Book_Collection
        {
            public int BookId { get; set; }
            public Book Book { get; set; }

            public int CollectionId { get; set; }
            public Collection Collection { get; set; }
        }
}

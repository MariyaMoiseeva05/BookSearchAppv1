using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
        public class TypeOfLit_Book
        {
            public int BookId { get; set; }
            public Book Book { get; set; }

            public int TypeId { get; set; }
            public Type_of_literature TypeLit { get; set; }
        }
}

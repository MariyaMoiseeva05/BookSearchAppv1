using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
        public class Book_Character
        {
            public int BookId { get; set; }
            public Book Book { get; set; }

            public int CharacterId { get; set; }
            public Character Character { get; set; }
        }
}

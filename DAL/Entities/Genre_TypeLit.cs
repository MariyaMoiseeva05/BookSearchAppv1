using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Genre_TypeLit
    {
            public int TypeLitId { get; set; }
            public Type_of_literature Type_of_literature { get; set; }

            public int GenreId { get; set; }
            public Genre Genre { get; set; }
    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class Genre_TypeLitModel
    {
            public int TypeLitId { get; set; }

            public int GenreId { get; set; }
            public Type_of_literature Type_of_literature { get; set; }
            public Genre Genre { get; set; }
            public Genre_TypeLitModel() { }
            public Genre_TypeLitModel(Genre_TypeLit gl)
            {
                TypeLitId = gl.TypeLitId;
                GenreId = gl.GenreId;
                Type_of_literature = gl.Type_of_literature;
                Genre = gl.Genre;

            }
        
    }
}

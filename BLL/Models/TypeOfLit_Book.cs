using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class TypeOfLit_BookModel
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int TypeId { get; set; }
        public Type_of_literature TypeLit { get; set; }

        public TypeOfLit_BookModel() { }
        public TypeOfLit_BookModel(TypeOfLit_Book lb) {
            BookId = lb.BookId;
            TypeId = lb.TypeId;
            Book = lb.Book;
            TypeLit = lb.TypeLit;
        }

    }
}

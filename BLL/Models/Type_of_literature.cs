using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class Type_of_literatureModel
    {
        public int Type_of_literatureId { get; set; }
        public string Name_Type { get; set; }
        public virtual ICollection<TypeOfLit_Book> Book { get; set; }
        public Type_of_literatureModel() { }
        public Type_of_literatureModel(Type_of_literature t)
        {

            Type_of_literatureId = t.Type_of_literatureId;
            Name_Type = t.Name_Type;
            Book = t.Book;

        }

    }
}

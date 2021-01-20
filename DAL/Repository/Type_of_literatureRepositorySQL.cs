using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class Type_of_literatureRepositorySQL : IRepository<Type_of_literature>
    {
        private BookSearchContext db;
        public Type_of_literatureRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Type_of_literature Type_of_literature)
        {
            db.Type_Of_Literatures.Add(Type_of_literature);
        }

        public void Delete(int? id)
        {
            Type_of_literature Type_of_literature = db.Type_Of_Literatures.Find(id);
            if (Type_of_literature != null)
                db.Type_Of_Literatures.Remove(Type_of_literature);
        }

        public Type_of_literature GetItem(int? id)
        {
            return db.Type_Of_Literatures.Find(id);
        }

        public IEnumerable<Type_of_literature> GetAll()
        {
            return db.Type_Of_Literatures.ToList();
        }

        public void Update(Type_of_literature Type_of_literature, int? tlId)
        {
            var tl = db.Type_Of_Literatures.Find(tlId);

            tl.Name_Type = Type_of_literature.Name_Type;
            tl.Book = Type_of_literature.Book;
            tl.Genres = Type_of_literature.Genres;

            db.Type_Of_Literatures.Update(tl);
            db.SaveChanges();
        }
    }
}

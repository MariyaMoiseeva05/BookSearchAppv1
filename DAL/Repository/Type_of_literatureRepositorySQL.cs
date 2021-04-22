using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public object Create(Type_of_literature Type_of_literature)
        {
            db.Type_Of_Literatures.Add(Type_of_literature);
            db.SaveChanges();
            return Type_of_literature.Type_of_literatureId;
        }

        public void Delete(object id)
        {
            Type_of_literature Type_of_literature = db.Type_Of_Literatures.Find((int)id);
            if (Type_of_literature != null)
                db.Type_Of_Literatures.Remove(Type_of_literature);
        }

        public Type_of_literature GetItem(object id)
        {
            return db.Type_Of_Literatures
                .Include(t => t.Book)
                .SingleOrDefault(t => t.Type_of_literatureId == (int) id);
        }

        public IEnumerable<Type_of_literature> GetAll()
        {
            return db.Type_Of_Literatures.ToList();
        }

        public void Update(Type_of_literature Type_of_literature, object tlId)
        {
            var tl = db.Type_Of_Literatures.Find((int)tlId);

            tl.Name_Type = Type_of_literature.Name_Type;
            tl.Book = Type_of_literature.Book;

            db.Type_Of_Literatures.Update(tl);
            db.SaveChanges();
        }
    }
}

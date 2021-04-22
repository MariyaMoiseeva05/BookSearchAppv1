using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class TypeOfLiteratureBooksRepositorySQL : IRepository<TypeOfLit_Book>
    {
        private BookSearchContext db;
        public TypeOfLiteratureBooksRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public object Create(TypeOfLit_Book TypeOfLit_Book)
        {
            db.TypeOfLit_Books.Add(TypeOfLit_Book);
            db.SaveChanges();
            return TypeOfLit_Book.TypeId;
        }

        public void Delete(object id)
        {
            TypeOfLit_Book TypeOfLit_Book = db.TypeOfLit_Books.Find((int)id);
            if (TypeOfLit_Book != null)
                db.TypeOfLit_Books.Remove(TypeOfLit_Book);
        }

        public TypeOfLit_Book GetItem(object id)
        {
            return db.TypeOfLit_Books.Find((int)id);
        }

        public IEnumerable<TypeOfLit_Book> GetAll()
        {
            return db.TypeOfLit_Books.ToList();
        }

        public void Update(TypeOfLit_Book TypeOfLit_Book, object id)
        {
            var cn = db.TypeOfLit_Books.Find((int)id);
            cn.TypeId = TypeOfLit_Book.TypeId;
            cn.BookId = TypeOfLit_Book.BookId;

            db.TypeOfLit_Books.Update(cn);
            db.SaveChanges();
        }
    }
}

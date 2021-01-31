using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public class CollectionRepositorySQL : IRepository<Collection>
    {
        private BookSearchContext db;
        public CollectionRepositorySQL(BookSearchContext dbcontext)
        {
            this.db = dbcontext;
        }
        public void Create(Collection Collection)
        {
            db.Collections.Add(Collection);
            db.SaveChanges();
        }
        public void Delete(object collectionId)
        {
            var collection = db.Collections.FirstOrDefault(x => x.CollectionId == (int)collectionId);

            if (collection != null)
            {
                db.Collections.Remove(collection);
                db.SaveChanges();
            }
        }
        public Collection GetItem(object id)
        {
            return db.Collections
                .Include(cl => cl.Book_Collections).ThenInclude(gn => gn.Book)
                .First(b => b.CollectionId == (int)id);
        }

        public IEnumerable<Collection> GetAll()
        {
            return db.Collections
                .Include(cl => cl.Book_Collections).ThenInclude(gn => gn.Book)
                .ToList();
        }
        public void Update(Collection Collection, object collectionId)
        {
            var collection = db.Collections.Find((int)collectionId);
            collection.Title = Collection.Title;
            collection.Info = Collection.Info;
            collection.ImagePath = Collection.ImagePath;
            collection.ImageLink = Collection.ImageLink;
            collection.Book_Collections = Collection.Book_Collections;


            db.Collections.Update(collection);
            db.SaveChanges();
        }
    }
}

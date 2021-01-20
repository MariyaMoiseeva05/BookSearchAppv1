using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class AuthorRepositorySQL : IRepository<Author>
    {
        private BookSearchContext db;
        public AuthorRepositorySQL(BookSearchContext dbcontext)
        {
            db = dbcontext;
        }
        public void Create(Author Author)
        {
            db.Authors.Add(Author);
        }

        public void Delete(int? id)
        {
            Author Author = db.Authors.Find(id);
            if (Author != null)
                db.Authors.Remove(Author);
        }

        public Author GetItem(int? id)
        {
            return db.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public void Update(Author Author, int? authorId)
        {
            var author = db.Authors.Find(authorId);
            author.Full_name = Author.Full_name;
            author.Pseudonym = Author.Pseudonym;
            author.Date_of_Birth = Author.Date_of_Birth;
            author.Date_of_Death = Author.Date_of_Death;
            author.Place_of_Birth = Author.Place_of_Birth;
            author.Place_of_Death = Author.Place_of_Death;
            author.Citizenship = Author.Citizenship;
            author.Occupation = Author.Occupation;
            author.Years_of_creativity = Author.Years_of_creativity;
            author.Language_of_works = Author.Language_of_works;
            author.Debut = Author.Debut;
            author.Prizes = Author.Prizes;
            author.Awards = author.Awards;
            author.ImageLink = author.ImageLink;
            author.ImagePath = author.ImagePath;
            author.Book = Author.Book;
            author.Interesting_fact = Author.Interesting_fact;
            author.Details = Author.Details;
            db.Authors.Update(author);
            db.SaveChanges();
        }
    }
}

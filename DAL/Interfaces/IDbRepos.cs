using DAL.Entities;
using DAL.Repository;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Interesting_fact> Interesting_facts { get; }
        IRepository<News> News { get; }
        IRepository<Quote> Quotes { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Think> Thinks { get; }
        IRepository<Type_of_literature> Type_of_literatures { get; }
        IRepository<Tag> Tags { get; }
        IRepository<User> Users { get; }
        IRepository<Collection> Collections { get; }
        IRepository<Character> Characters { get; }

        int Save();
    }
}

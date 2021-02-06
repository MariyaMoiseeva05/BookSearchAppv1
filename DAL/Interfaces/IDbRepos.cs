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
        IRepository<Advert> Adverts { get; }
        IRepository<Comment_Advert> Comment_Adverts { get; }
        IRepository<Featured_Advert> Featured_Adverts { get; }
        IRepository<Like_Advert> Like_Adverts { get; }
        IRepository<Locality> Localities { get; }
        IRepository<Message> Messages { get; }
        IRepository<Featured_Book> Featured_Books { get; }
        int Save();
    }
}

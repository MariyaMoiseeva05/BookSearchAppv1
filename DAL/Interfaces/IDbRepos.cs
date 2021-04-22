using DAL.Entities;
using DAL.Repository;

namespace DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        IRepository<Author_Book> Authors_Books { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Genre_Book> Genres_Books { get; }
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
        IRepository<Featured_Advert> Featured_Adverts { get; }
        IRepository<Like_Advert> Like_Adverts { get; }
        IRepository<Locality> Localities { get; }
        IRepository<Message> Messages { get; }
        IRepository<Featured_Book> Featured_Books { get; }
        IRepository<Comment_Review> Comment_Reviews { get; }
        IRepository<Comment_News> Comment_News { get; }
        IRepository<TypeOfLit_Book> Type_of_literaturesBooks { get; }
        int Save();
    }
}

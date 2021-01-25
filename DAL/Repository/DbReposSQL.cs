using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class DbReposSQL : IDbRepos
    {
        private BookSearchContext db;
        private BookRepositorySQL bookRepository;
        private AuthorRepositorySQL authorRepository;
        private CommentRepositorySQL commentRepository;
        private GenreRepositorySQL genreRepository;
        private Interesting_factRepositorySQL interesting_factRepository;
        private NewsRepositorySQL newsRepository;
        private QuoteRepositorySQL quoteRepository;
        private ReviewRepositorySQL reviewRepository;
        private ThinkRepositorySQL thinkRepository;
        private Type_of_literatureRepositorySQL type_of_literatureRepository;
        private TagRepositorySQL tagRepository;
        private UserRepositorySQL userRepository;

        public DbReposSQL(DbContextOptions<BookSearchContext> options)
        {
            db = new BookSearchContext(options);
        }

        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepositorySQL(db);
                return (IRepository<Book>)bookRepository;
            }
        }

        public IRepository<Author> Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new AuthorRepositorySQL(db);
                return (IRepository<Author>)authorRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepositorySQL(db);
                return (IRepository<Comment>)commentRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepositorySQL(db);
                return (IRepository<Genre>)genreRepository;
            }
        }

        public IRepository<Interesting_fact> Interesting_facts
        {
            get
            {
                if (interesting_factRepository == null)
                    interesting_factRepository = new Interesting_factRepositorySQL(db);
                return (IRepository<Interesting_fact>)interesting_factRepository;
            }
        }

        public IRepository<News> News
        {
            get
            {
                if (newsRepository == null)
                    newsRepository = new NewsRepositorySQL(db);
                return (IRepository<News>)newsRepository;
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepositorySQL(db);
                return (IRepository<Tag>)tagRepository;
            }
        }

        public IRepository<Quote> Quotes
        {
            get
            {
                if (quoteRepository == null)
                    quoteRepository = new QuoteRepositorySQL(db);
                return (IRepository<Quote>)quoteRepository;
            }
        }

        public IRepository<Review> Reviews
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepositorySQL(db);
                return (IRepository<Review>)reviewRepository;
            }
        }
        public IRepository<Think> Thinks
        {
            get
            {
                if (thinkRepository == null)
                    thinkRepository = new ThinkRepositorySQL(db);
                return (IRepository<Think>)thinkRepository;
            }
        }

        public IRepository<Type_of_literature> Type_of_literatures
        {
            get
            {
                if (type_of_literatureRepository == null)
                    type_of_literatureRepository = new Type_of_literatureRepositorySQL(db);
                return (IRepository<Type_of_literature>)type_of_literatureRepository;
            }
        }

       public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepositorySQL(db);
                return userRepository;
            }
        }


        public int Save()
        {
            return db.SaveChanges();
        }
    }

}


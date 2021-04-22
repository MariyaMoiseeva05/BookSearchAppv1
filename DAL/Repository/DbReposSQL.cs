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
        private Author_BookRepositorySQL author_BookRepository;
        private GenreRepositorySQL genreRepository;
        private Interesting_factRepositorySQL interesting_factRepository;
        private NewsRepositorySQL newsRepository;
        private QuoteRepositorySQL quoteRepository;
        private ReviewRepositorySQL reviewRepository;
        private ThinkRepositorySQL thinkRepository;
        private Type_of_literatureRepositorySQL type_of_literatureRepository;
        private TagRepositorySQL tagRepository;
        private UserRepositorySQL userRepository;
        private CollectionRepositorySQL collectionRepository;
        private CharacterRepositorySQL characterRepository;
        private MessageRepositorySQL messageRepository;
        private AdvertRepositorySQL advertRepository;
        private LocalityRepositorySQL localityRepository;
        private Featured_AdvertRepositorySQL featured_advertRepository;
        private Featured_BooksRepositorySQL featured_booksRepository;
        private Like_AdvertRepositorySQL like_advertRepository;
        private Comment_ReviewRepositorySQL comment_reviewRepository;
        private Comment_NewsRepositorySQL comment_newsRepository;
        private TypeOfLiteratureBooksRepositorySQL type_of_lit_bookRepository;
        private GenresBooksRepositorySQL genresBooksRepository;

        public DbReposSQL(DbContextOptions<BookSearchContext> options)
        {
            db = new BookSearchContext(options);
        }

        public IRepository<Book> Books {
            get {
                if (bookRepository == null)
                    bookRepository = new BookRepositorySQL(db);
                return bookRepository;
            }
        }

        public IRepository<Author> Authors {
            get {
                if (authorRepository == null)
                    authorRepository = new AuthorRepositorySQL(db);
                return authorRepository;
            }
        }

        public IRepository<Author_Book> Authors_Books {
            get {
                if (author_BookRepository == null)

                    author_BookRepository = new Author_BookRepositorySQL(db);

                return author_BookRepository;
            }
        }

        public IRepository<Genre> Genres {
            get {
                if (genreRepository == null)
                    genreRepository = new GenreRepositorySQL(db);
                return genreRepository;
            }
        }
        public IRepository<Genre_Book> Genres_Books {
            get {
                if (genresBooksRepository == null)
                    genresBooksRepository = new GenresBooksRepositorySQL(db);
                return genresBooksRepository;
            }
        }

        public IRepository<Interesting_fact> Interesting_facts {
            get {
                if (interesting_factRepository == null)
                    interesting_factRepository = new Interesting_factRepositorySQL(db);
                return interesting_factRepository;
            }
        }

        public IRepository<News> News {
            get {
                if (newsRepository == null)
                    newsRepository = new NewsRepositorySQL(db);
                return newsRepository;
            }
        }

        public IRepository<Tag> Tags {
            get {
                if (tagRepository == null)
                    tagRepository = new TagRepositorySQL(db);
                return tagRepository;
            }
        }

        public IRepository<Quote> Quotes {
            get {
                if (quoteRepository == null)
                    quoteRepository = new QuoteRepositorySQL(db);
                return quoteRepository;
            }
        }

        public IRepository<Review> Reviews {
            get {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepositorySQL(db);
                return reviewRepository;
            }
        }
        public IRepository<Think> Thinks {
            get {
                if (thinkRepository == null)
                    thinkRepository = new ThinkRepositorySQL(db);
                return thinkRepository;
            }
        }

        public IRepository<Type_of_literature> Type_of_literatures {
            get {
                if (type_of_literatureRepository == null)
                    type_of_literatureRepository = new Type_of_literatureRepositorySQL(db);
                return type_of_literatureRepository;
            }
        }

        public IRepository<TypeOfLit_Book> Type_of_literaturesBooks {
            get {
                if (type_of_lit_bookRepository == null)
                    type_of_lit_bookRepository = new TypeOfLiteratureBooksRepositorySQL(db);
                return type_of_lit_bookRepository;
            }
        }

        public IRepository<User> Users {
            get {
                if (userRepository == null)
                    userRepository = new UserRepositorySQL(db);
                return userRepository;
            }
        }

        public IRepository<Character> Characters {
            get {
                if (characterRepository == null)
                    characterRepository = new CharacterRepositorySQL(db);
                return characterRepository;
            }
        }
        public IRepository<Collection> Collections {
            get {
                if (collectionRepository == null)
                    collectionRepository = new CollectionRepositorySQL(db);
                return collectionRepository;
            }
        }

        public IRepository<Advert> Adverts {
            get {
                if (advertRepository == null)
                    advertRepository = new AdvertRepositorySQL(db);
                return advertRepository;
            }
        }



        public IRepository<Like_Advert> Like_Adverts {
            get {
                if (like_advertRepository == null)
                    like_advertRepository = new Like_AdvertRepositorySQL(db);
                return like_advertRepository;
            }
        }

        public IRepository<Featured_Advert> Featured_Adverts {
            get {
                if (featured_advertRepository == null)
                    featured_advertRepository = new Featured_AdvertRepositorySQL(db);
                return featured_advertRepository;
            }
        }

        public IRepository<Featured_Book> Featured_Books {
            get {
                if (featured_booksRepository == null)
                    featured_booksRepository = new Featured_BooksRepositorySQL(db);
                return featured_booksRepository;
            }
        }

        public IRepository<Message> Messages {
            get {
                if (messageRepository == null)
                    messageRepository = new MessageRepositorySQL(db);
                return messageRepository;
            }
        }

        public IRepository<Locality> Localities {
            get {
                if (localityRepository == null)
                    localityRepository = new LocalityRepositorySQL(db);
                return localityRepository;
            }
        }

        public IRepository<Comment_Review> Comment_Reviews {
            get {
                if (comment_reviewRepository == null)
                    comment_reviewRepository = new Comment_ReviewRepositorySQL(db);
                return comment_reviewRepository;
            }
        }

        public IRepository<Comment_News> Comment_News {
            get {
                if (comment_newsRepository == null)
                    comment_newsRepository = new Comment_NewsRepositorySQL(db);
                return comment_newsRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }

}


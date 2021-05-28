using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL.Data
{
    public class DbDataOperation : IDbCRUD
    {
        IDbRepos db;
        public DbDataOperation(IDbRepos repos)
        {
            db = repos;
        }

        #region Author
        public IEnumerable<AuthorModel> GetAllAuthors()
        {
      
            return db.Authors.GetAll().Select(i => new AuthorModel(i))
                .OrderBy(a => a.Full_name)
               // .Skip((authorParameters.PageNumber - 1)*authorParameters.PageSize)
                //.Take(authorParameters.PageSize)
                .ToList();
        }


        public AuthorModel GetAuthor(int Id)
        {
            return new AuthorModel(db.Authors.GetItem(Id));
        }

        public void IndexAuthor(string sortOrder, string searchString, string currentFilter, int? pageNumber) {
           
        }

        public void CreateAuthor(AuthorModel at)
        {
            int id = (int)db.Authors.Create(new Author()
            {
                Full_name = at.Full_name,
                Pseudonym = at.Pseudonym,
                Date_of_Birth = at.Date_of_Birth,
                Date_of_Death = at.Date_of_Death,
                Place_of_Birth = at.Place_of_Birth,
                Place_of_Death = at.Place_of_Death,
                Citizenship = at.Citizenship,
                Occupation = at.Occupation,
                Years_of_creativity = at.Years_of_creativity,
                Debut = at.Debut,
                Prizes = at.Prizes,
                Awards = at.Awards,
                Language_of_works = at.Language_of_works,
                ImagePath = at.ImagePath,
                ImageLink = at.ImageLink,
                Book = at.Book,
                Interesting_fact = at.Interesting_fact,
                Details = at.Details
            });
            Save();
        }

        public void UpdateAuthor(AuthorModel a, int authorId)
        {
            Author av = db.Authors.GetItem(a.AuthorId);
            av.Full_name = a.Full_name;
            av.Pseudonym = a.Pseudonym;
            av.Date_of_Birth = a.Date_of_Birth;
            av.Date_of_Death = a.Date_of_Death;
            av.Place_of_Birth = a.Place_of_Birth;
            av.Place_of_Death = a.Place_of_Death;
            av.Citizenship = a.Citizenship;
            av.Occupation = a.Occupation;
            av.Years_of_creativity = a.Years_of_creativity;
            av.Language_of_works = a.Language_of_works;
            av.Debut = a.Debut;
            av.Prizes = a.Prizes;
            av.Awards = av.Awards;
            av.ImageLink = av.ImageLink;
            av.Book = a.Book;
            av.Interesting_fact = a.Interesting_fact;
            av.Details = a.Details;

            Save();
        }

        public void DeleteAuthor(int id)
        {
            Author a = db.Authors.GetItem(id);
            if (a != null)
            {
                db.Authors.Delete(a.AuthorId);
                Save();
            }
        }
        #endregion

        #region Book
         /*public PageList<BookModel> GetAllBooks(BookParameters bookParameters)
        {
                 IEnumerable<BookModel> books = db.Books.GetAll().Select(i => new BookModel(i)).OrderBy(b => b.Title)
                .Skip((bookParameters.PageNumber - 1)*bookParameters.PageSize)
                .Take(bookParameters.PageSize)
                .ToList();


        }*/

    public IEnumerable<BookModel> GetAllBooks()
        {
            return db.Books.GetAll().Select(i => new BookModel(i))
                .OrderBy(b => b.Title)
                //.Skip((bookParameters.PageNumber - 1)*bookParameters.PageSize)
                //.Take(bookParameters.PageSize)
                .ToList();
        }

        public BookModel GetBook(int Id)
        {
            DAL.Entities.Book b = db.Books.GetItem(Id);
            if (b != null)
                return new BookModel(b);
            else return null;
        }


        public void CreateBook(BookModel b, ICollection<string> a, ICollection<string> g, ICollection<string> tl)
        {
            int id = (int)db.Books.Create(new Book()
            {
                Title = b.Title,
                Description = b.Description,
                Story = b.Story,
                Edition = b.Edition,
                Publication_date = b.Publication_date,
                ImagePath = b.ImagePath,
                ImageLink = b.ImageLink,
                Authors = b.Author,
                Screenings = b.Screenings,
                Types_of_literature = b.Type_of_literature,
                Quotes = b.Quote,
                Reviews = b.Review,
                Genres_Books = b.Genre_Books,
                Book_Collections = b.Book_Collections,
                Book_Characters = b.Book_Characters,
                Adverts = b.Adverts,
                Featured_Books = b.Featured_Books

            });
            Save();
            
            foreach (var s in tl)
            {
                DAL.Entities.TypeOfLit_Book typeOfLit_Book = new DAL.Entities.TypeOfLit_Book
                {
                    TypeId = int.Parse(s),
                    BookId = id
                };
                try
                {
                    db.Type_of_literaturesBooks.Create(typeOfLit_Book);
                }
                catch (DataException e)
                {
                    throw new Exception(e.Message);
                }
            }
            foreach (var s in g)
            {
                DAL.Entities.Genre_Book genre_book = new DAL.Entities.Genre_Book
                {
                    GenreId = int.Parse(s),
                    BookId = id
                };
                try
                {
                    db.Genres_Books.Create(genre_book);
                }
                catch (DataException e)
                {
                    throw new Exception(e.Message);
                }
            }
            foreach (var s in a)
            {
                DAL.Entities.Author_Book ab = new DAL.Entities.Author_Book
                {
                    AuthorId = int.Parse(s),
                    BookId = id
                };
                try
                {
                    db.Authors_Books.Create(ab);
                }
                catch (DataException e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public void UpdateBook(BookModel b, int bookId)
        {
            Book bk = db.Books.GetItem(b.BookID);
            bk.Title = b.Title;
            bk.Description = b.Description;
            bk.Story = b.Story;
            bk.Edition = b.Edition;
            bk.Publication_date = b.Publication_date;
            bk.ImagePath = b.ImagePath;
            bk.ImageLink = b.ImageLink;
            bk.Authors = b.Author;
            bk.Screenings = b.Screenings;
            bk.Types_of_literature = b.Type_of_literature;
            bk.Quotes = b.Quote;
            bk.Reviews = b.Review;
            bk.Genres_Books = b.Genre_Books;
            bk.Book_Collections = b.Book_Collections;
            bk.Book_Characters = b.Book_Characters;
            bk.Adverts = b.Adverts;
            bk.Featured_Books = b.Featured_Books;
            Save();
        }

        public void DeleteBook(int id)
        {
            Book a = db.Books.GetItem(id);
            if (a != null)
            {
                db.Books.Delete(a.BookID);
                Save();
            }
        }
        #endregion

        #region Genre
        public IEnumerable<GenreModel> GetAllGenres()
        {
            return db.Genres.GetAll().Select(i => new GenreModel(i)).OrderBy(n => n.NameGenre)
                .ToList();
        }

        public GenreModel GetGenre(int Id)
        {
            return new GenreModel(db.Genres.GetItem(Id));
        }

        public void CreateGenre(GenreModel g)
        {
            db.Genres.Create(new Genre()
            {
                NameGenre = g.NameGenre,
                Genre_Books = g.Genre_Books

            });
            Save();
        }

        public void UpdateGenre(GenreModel g)
        {
            Genre gr = db.Genres.GetItem(g.GenreId);
            gr.NameGenre = g.NameGenre;
            gr.Genre_Books = g.Genre_Books;

            Save();
        }

        public void DeleteGenre(int id)
        {
            Genre c = db.Genres.GetItem(id);
            if (c != null)
            {
                db.Genres.Delete(c.GenreId);
                Save();
            }
        }
        #endregion

        #region Interesting_fact
        public IEnumerable<Interesting_factModel> GetAllInteresting_facts()
        {
            return db.Interesting_facts.GetAll().Select(i => new Interesting_factModel(i)).ToList();
        }

        public Interesting_factModel GetInteresting_fact(int Id)
        {
            return new Interesting_factModel(db.Interesting_facts.GetItem(Id));
        }

        public void CreateInteresting_fact(Interesting_factModel f)
        {
            db.Interesting_facts.Create(new Interesting_fact()
            {
                AuthorID = f.AuthorID,
                Content = f.Content,
                Author = f.Author,
                ImageLink = f.ImageLink,
                ImagePath = f.ImagePath

            });
            Save();
        }

        public void UpdateInteresting_fact(Interesting_factModel f)
        {
            Interesting_fact fi = db.Interesting_facts.GetItem(f.FactId);
            fi.AuthorID = f.AuthorID;
            fi.Content = f.Content;
            fi.Author = f.Author;
            fi.ImageLink = f.ImageLink;
            fi.ImagePath = f.ImagePath;

            Save();
        }

        public void DeleteInteresting_fact(int id)
        {
            Interesting_fact f = db.Interesting_facts.GetItem(id);
            if (f != null)
            {
                db.Interesting_facts.Delete(f.FactId);
                Save();
            }
        }
        #endregion

        #region News
        public IEnumerable<NewsModel> GetAllNews()
        {
            return db.News.GetAll().Select(i => new NewsModel(i)).ToList();
        }

        public NewsModel GetNews(int Id)
        {
            return new NewsModel(db.News.GetItem(Id));
        }

        public void CreateNews(NewsModel n)
        {
            db.News.Create(new News()
            {
                Topic = n.Topic,
                Title = n.Title,
                Date_of_creation = n.Date_of_creation,
                Content = n.Content,
                Tags = n.Tags,
                Comments = n.Comments,
                Source = n.Source,
                ImageLink = n.ImageLink,
                ImagePath = n.ImagePath

            });
            Save();
        }

        public void UpdateNews(NewsModel n)
        {
            News nw = db.News.GetItem(n.NewsId);
            nw.Topic = n.Topic;
            nw.Title = n.Title;
            nw.Tags = n.Tags;
            nw.Comments = n.Comments;
            nw.ImagePath = n.ImagePath;
            nw.ImageLink = n.ImageLink;
            nw.Date_of_creation = n.Date_of_creation;
            nw.Content = n.Content;
            nw.Source = n.Source;
            Save();
        }

        public void DeleteNews(int id)
        {
            News n = db.News.GetItem(id);
            if (n != null)
            {
                db.News.Delete(n.NewsId);
                Save();
            }
        }
        #endregion

        #region Tag
        public IEnumerable<TagModel> GetAllTags()
        {
            return db.Tags.GetAll().Select(i => new TagModel(i)).ToList();
        }

        public TagModel GetTags(int Id)
        {
            return new TagModel(db.Tags.GetItem(Id));
        }

        public void CreateTags(TagModel t)
        {
            db.Tags.Create(new Tag()
            {
                Name = t.Name,
                News = t.News
            });
            Save();
        }

        public void UpdateTags(TagModel t)
        {
            Tag tg = db.Tags.GetItem(t.Id);
            tg.Name = t.Name;
            tg.News = t.News;
            Save();
        }

        public void DeleteTags(int id)
        {
            Tag t = db.Tags.GetItem(id);
            if (t != null)
            {
                db.Tags.Delete(t.Id);
                Save();
            }
        }
        #endregion

        #region Quote
        public IEnumerable<QuoteModel> GetAllQuotes()
        {
            return db.Quotes.GetAll().Select(i => new QuoteModel(i)).ToList();
        }

        public QuoteModel GetQuote(int Id)
        {
            return new QuoteModel(db.Quotes.GetItem(Id));
        }

        public void CreateQuote(QuoteModel q)
        {
            db.Quotes.Create(new Quote()
            {
                BookID = q.BookID,
                Content = q.Content,
                Book = q.Book,
                UserID = q.UserId,
                User = q.User,
                Like = q.Like
            });
            Save();
        }

        public void UpdateQuote(QuoteModel q)
        {
            Quote qt = db.Quotes.GetItem(q.QuoteId);

            qt.BookID = q.BookID;
            qt.Content = q.Content;
            qt.Book = q.Book;
            qt.UserID = q.UserId;
            qt.User = q.User;
            qt.Like = q.Like;
            Save();
        }

        public void DeleteQuote(int id)
        {
            Quote q = db.Quotes.GetItem(id);
            if (q != null)
            {
                db.News.Delete(q.QuoteId);
                Save();
            }
        }
        #endregion

        #region Review
        public IEnumerable<ReviewModel> GetAllReviews()
        {
            return db.Reviews.GetAll().Select(i => new ReviewModel(i)).ToList();
        }

        public ReviewModel GetReview(int Id)
        {
            return new ReviewModel(db.Reviews.GetItem(Id));
        }

        public void CreateReview(ReviewModel r)
        {
            int id = (int)db.Reviews.Create(new Review()
            {
                Title = r.Title,
                Text = r.Text,
                Type = r.Type,
                BookID = r.BookID,
                UserID = r.UserID,
                User = r.User,
                Book = r.Book,
                Comments = r.Comments,
                Rating = r.Rating
            });
            Save();
/*
            foreach (var rw in c)
            {
                DAL.Entities.Comment_Review cr = new DAL.Entities.Comment_Review
                {
                    Comment_ReviewId = int.Parse(rw),
                    ReviewId = id
                };
                try
                {
                    db.Comment_Reviews.Create(cr);
                }
                catch (DataException e)
                {
                    throw new Exception(e.Message);
                }
            }*/

        }

        public void UpdateReview(ReviewModel r, int reviewId)
        {
            Review rw = db.Reviews.GetItem(r.RewiewId);

            rw.Title = r.Title;
            rw.Text = r.Text;
            rw.Type = r.Type;
            rw.BookID = r.BookID;
            rw.UserID = r.UserID;
            rw.Book = r.Book;
            rw.Comments = r.Comments;
            rw.User = r.User;
            rw.Rating = r.Rating;
            Save();
        }

        public void DeleteReview(int id)
        {
            Review r = db.Reviews.GetItem(id);
            if (r != null)
            {
                db.News.Delete(r.RewiewId);
                Save();
            }
        }
        #endregion

        #region Think
        public IEnumerable<ThinkModel> GetAllThinks()
        {
            return db.Thinks.GetAll().Select(i => new ThinkModel(i)).ToList();
        }

        public ThinkModel GetThink(int Id)
        {
            return new ThinkModel(db.Thinks.GetItem(Id));
        }

        public void CreateThink(ThinkModel t)
        {
            db.Thinks.Create(new Think()
            {
                Title = t.Title,
                Content = t.Content,
                Date_of_creation = t.Date_of_creation,
                UserId = t.UserId,
                User = t.User

            });
            Save();
        }

        public void UpdateThink(ThinkModel t, int thinkId)
        {
            Think th = db.Thinks.GetItem(t.ThinkId);

            th.Title = t.Title;
            th.Content = t.Content;
            th.Date_of_creation = t.Date_of_creation;
            th.UserId = t.UserId;
            th.User = t.User;
            Save();
        }

        public void DeleteThink(int id)
        {
            Think t = db.Thinks.GetItem(id);
            if (t != null)
            {
                db.News.Delete(t.ThinkId);
                Save();
            }
        }
        #endregion

        #region Type_of_literature
        public IEnumerable<Type_of_literatureModel> GetAllType_of_literatures()
        {
            return db.Type_of_literatures.GetAll().Select(i => new Type_of_literatureModel(i)).ToList();
        }

        public Type_of_literatureModel GetType_of_literature(int Id)
        {
            return new Type_of_literatureModel(db.Type_of_literatures.GetItem(Id));
        }

        public void CreateType_of_literature(Type_of_literatureModel t)
        {
            db.Type_of_literatures.Create(new Type_of_literature()
            {
                Name_Type = t.Name_Type,
                Book = t.Book

            });
            Save();
        }

        public void UpdateType_of_literature(Type_of_literatureModel t)
        {
            Type_of_literature tl = db.Type_of_literatures.GetItem(t.Type_of_literatureId);

            tl.Name_Type = t.Name_Type;
            tl.Book = t.Book;
            Save();
        }

        public void DeleteType_of_literature(int id)
        {
            Type_of_literature t = db.Type_of_literatures.GetItem(id);
            if (t != null)
            {
                db.News.Delete(t.Type_of_literatureId);
                Save();
            }
        }
        #endregion

        #region User
        public IEnumerable<UserModel> GetAllUsers()
        {
            return db.Users.GetAll().Select(i => new UserModel(i)).ToList();
        }

        public UserModel GetUser(string Id)
        {
            return new UserModel(db.Users.GetItem(Id));
        }

        public void CreateUser(UserModel u)
        {
            db.Users.Create(new User()
            {
                Login = u.Login,
                Name = u.Name,
                Surname = u.Surname,
                Sex = u.Sex,
                Interest = u.Interest,
                Favorite_books = u.Favorite_books,
                Country = u.Country,
                Place = u.Place,
                Date_of_Birth = u.Date_of_Birth,
                About_me = u.About_me,
                ImagePath = u.ImagePath,
                ImageLink = u.ImageLink,
                Review = u.Review,
                Think = u.Think,
                Quote = u.Quote,
                Message = u.Message,
                Advert = u.Advert,
                Featured_Adverts = u.Featured_Adverts,
                Featured_Books = u.Featured_Books
        });
            Save();
        }

        public void UpdateUser(UserModel u, string id)
        {
            User us = db.Users.GetItem(id);
            us.Login = u.Login;
            us.Name = u.Name;
            us.Surname = u.Surname;
            us.Sex = u.Sex;
            us.Interest = u.Interest;
            us.Favorite_books = u.Favorite_books;
            us.Country = u.Country;
            us.Place = u.Place;
            us.Date_of_Birth = u.Date_of_Birth;
            us.About_me = u.About_me;
            us.ImageLink = u.ImageLink;
            us.ImagePath = u.ImagePath;
            us.Quote = u.Quote;
            us.Review = u.Review;
            us.Think = u.Think;
            us.Message = u.Message;
            us.Advert = u.Advert;
            us.Featured_Adverts = u.Featured_Adverts;
            us.Featured_Books = u.Featured_Books;

            Save();
        }

        public void DeleteUser(string id)
        {
            User u = db.Users.GetItem(id);
            if (u != null)
            {
                db.Users.Delete(u.Id);
                Save();
            }
        }
        #endregion

        #region Collection
        public IEnumerable<CollectionModel> GetAllCollections()
        {
            return db.Collections.GetAll().Select(i => new CollectionModel(i)).ToList();
        }

        public CollectionModel GetCollection(int Id)
        {
            return new CollectionModel(db.Collections.GetItem(Id));
        }

        public void CreateCollection(CollectionModel cl)
        {
            db.Collections.Create(new Collection()
            {
                Title = cl.Title,
                Info = cl.Info,
                ImagePath = cl.ImagePath,
                ImageLink = cl.ImageLink,
                Book_Collections = cl.Book_Collections

            });
            Save();
        }

        public void UpdateCollection(CollectionModel cl)
        {
            Collection co = db.Collections.GetItem(cl.CollectionId);
            co.Title = cl.Title;
            co.Info = cl.Info;
            co.ImagePath = cl.ImagePath;
            co.ImageLink = cl.ImageLink;
            co.Book_Collections = cl.Book_Collections;
            Save();
        }

        public void DeleteCollection(int id)
        {
            Collection a = db.Collections.GetItem(id);
            if (a != null)
            {
                db.Collections.Delete(a.CollectionId);
                Save();
            }
        }
        #endregion

        #region Character
        public IEnumerable<CharacterModel> GetAllCharacters()
        {
            return db.Characters.GetAll().Select(i => new CharacterModel(i)).ToList();
        }

        public CharacterModel GetCharacter(int Id)
        {
            return new CharacterModel(db.Characters.GetItem(Id));
        }

        public void CreateCharacter(CharacterModel ch)
        {
            db.Characters.Create(new Character()
            {
                Name = ch.Name,
                Other_name = ch.Other_name,
                Sex = ch.Sex,
                View = ch.View,
                Biography = ch.Biography,
                Appearance = ch.Appearance,
                Date_of_Birth = ch.Date_of_Birth,
                Date_of_Death = ch.Date_of_Death,
                ImagePath = ch.ImagePath,
                ImageLink = ch.ImageLink,
                Book_Characters = ch.Book_Characters

            });
            Save();
        }

        public void UpdateCharacter(CharacterModel ch)
        {
            Character cr = db.Characters.GetItem(ch.CharacterId);
            cr.Name = ch.Name;
            cr.Other_name = ch.Other_name;
            cr.Sex = ch.Sex;
            cr.View = ch.View;
            cr.Biography = ch.Biography;
            cr.Appearance = ch.Appearance;
            cr.Date_of_Birth = ch.Date_of_Birth;
            cr.Date_of_Death = ch.Date_of_Death;
            cr.ImagePath = ch.ImagePath;
            cr.ImageLink = ch.ImageLink;
            cr.Book_Characters = ch.Book_Characters;
            Save();
        }

        public void DeleteCharacter(int id)
        {
            Character a = db.Characters.GetItem(id);
            if (a != null)
            {
                db.Characters.Delete(a.CharacterId);
                Save();
            }
        }
        #endregion

        #region Advert
        public IEnumerable<AdvertModel> GetAllAdverts()
        {
            return db.Adverts.GetAll().Select(i => new AdvertModel(i)).ToList();
        }

        public AdvertModel GetAdvert(int Id)
        {
            return new AdvertModel(db.Adverts.GetItem(Id));
        }

        public void CreateAdvert(AdvertModel a)
        {
            db.Adverts.Create(new Advert()
            {
                Content = a.Content,
                LocalityId = a.LocalityId,
                Locality = a.Locality,
                ExchangeCompleted = a.ExchangeCompleted,
                SaleCompleted = a.SaleCompleted,
                Finish = a.Finish,
                Date_of_Create = a.Date_of_Create,
                Number_of_views = a.Number_of_views,
                Delivery = a.Delivery,
                Pickup = a.Pickup,
                Message = a.Message,
                Featured_Adverts = a.Featured_Adverts,
                Book = a.Book,
                BookId = a.BookId,
                User = a.User,
                UserId = a.UserId

            });
            Save();
        }

        public void UpdateAdvert(AdvertModel a, int advertId)
        {
            Advert ad = db.Adverts.GetItem(a.AdvertID);
            ad.Content = a.Content;
            ad.LocalityId = a.LocalityId;
            ad.Locality = a.Locality;
            ad.ExchangeCompleted = a.ExchangeCompleted;
            ad.SaleCompleted = a.SaleCompleted;
            ad.Finish = a.Finish;
            ad.Date_of_Create = a.Date_of_Create;
            ad.Number_of_views = a.Number_of_views;
            ad.Delivery = a.Delivery;
            ad.Pickup = a.Pickup;
            ad.Message = a.Message;
            ad.Featured_Adverts = a.Featured_Adverts;
            ad.User = a.User;
            ad.UserId = a.UserId;
            ad.Book = a.Book;
            ad.BookId = ad.BookId;
            Save();
        }

        public void DeleteAdvert(int id)
        {
            Advert a = db.Adverts.GetItem(id);
            if (a != null)
            {
                db.Adverts.Delete(a.AdvertID);
                Save();
            }
        }
        #endregion


        #region FeaturedAdvert
        public IEnumerable<Featured_AdvertModel> GetAllFeaturedAdverts()
        {
            return db.Featured_Adverts.GetAll().Select(i => new Featured_AdvertModel(i)).ToList();
        }

        public Featured_AdvertModel GetFeaturedAdvert(int Id)
        {
            return new Featured_AdvertModel(db.Featured_Adverts.GetItem(Id));
        }

        public void CreateFeaturedAdvert(Featured_AdvertModel fa)
        {
            db.Featured_Adverts.Create(new Featured_Advert()
            {
                UserId = fa.UserId,
                User = fa.User,
                AdvertId = fa.AdvertId,
                Advert = fa.Advert
            });
            Save();
        }

        public void UpdateFeaturedAdvert(Featured_AdvertModel f, int featured_advertId)
        {
            Featured_Advert fa = db.Featured_Adverts.GetItem(f.Featured_AdvertId);

            fa.User = f.User;
            fa.UserId = f.UserId;
            fa.Advert = f.Advert;
            fa.AdvertId = f.AdvertId;
            Save();
        }

        public void DeleteFeaturedAdvert(int id)
        {
            Featured_Advert f = db.Featured_Adverts.GetItem(id);
            if (f != null)
            {
                db.Featured_Adverts.Delete(f.Featured_AdvertId);
                Save();
            }
        }
        #endregion

        #region FeaturedBook
        public IEnumerable<Featured_BookModel> GetAllFeaturedBooks()
        {
            return db.Featured_Books.GetAll().Select(i => new Featured_BookModel(i)).ToList();
        }

        public Featured_BookModel GetFeaturedBook(int Id)
        {
            return new Featured_BookModel(db.Featured_Books.GetItem(Id));
        }

        public void CreateFeaturedBook(Featured_BookModel b)
        {
            db.Featured_Books.Create(new Featured_Book()
            {
                UserId = b.UserId,
                User = b.User,
                BookId = b.BookId,
                Book = b.Book
            });
            Save();
        }

        public void UpdateFeaturedBook(Featured_BookModel b, int featured_booktId)
        {
            Featured_Book bk = db.Featured_Books.GetItem(b.Featured_BookId);

            bk.User = b.User;
            bk.UserId = b.UserId;
            bk.Book = b.Book;
            bk.BookId = b.BookId;
            Save();
        }

        public void DeleteFeaturedBook(int id)
        {
            Featured_Book b = db.Featured_Books.GetItem(id);
            if (b != null)
            {
                db.Featured_Books.Delete(b.Featured_BookId);
                Save();
            }
        }
        #endregion

        

        #region Locality
        public IEnumerable<LocalityModel> GetAllLocalities()
        {
            return db.Localities.GetAll().Select(i => new LocalityModel(i)).ToList();
        }

        public LocalityModel GetLocality(int Id)
        {
            return new LocalityModel(db.Localities.GetItem(Id));
        }

        public void CreateLocality(LocalityModel l)
        {
            db.Localities.Create(new Locality()
            {
                Type = l.Type,
                Name = l.Name,
                Timezone = l.Timezone,
                Adverts = l.Adverts
            });
            Save();
        }

        public void UpdateLocality(LocalityModel l, int localityId)
        {
            Locality lk = db.Localities.GetItem(l.LocalityId);

            lk.Type = l.Type;
            lk.Name = l.Name;
            lk.Timezone = l.Timezone;
            lk.Adverts = l.Adverts;
            Save();
        }

        public void DeleteLocality(int id)
        {
            Locality l = db.Localities.GetItem(id);
            if (l != null)
            {
                db.Localities.Delete(l.LocalityId);
                Save();
            }
        }
        #endregion

        #region Message
        public IEnumerable<MessageModel> GetAllMessages()
        {
            return db.Messages.GetAll().Select(i => new MessageModel(i)).ToList();
        }

        public MessageModel GetMessage(int Id)
        {
            return new MessageModel(db.Messages.GetItem(Id));
        }

        public void CreateMessage(MessageModel m)
        {
            db.Messages.Create(new Message()
            {
                Content = m.Content,
                Sender_Id = m.Sender_Id,
                Recipient_Id = m.Recipient_Id,
                Readed = m.Readed,
                Create_Message = m.Create_Message,
                User = m.User,
                Advert = m.Advert,
                AdvertId = m.AdvertId
            });
            Save();
        }

        public void UpdateMessage(MessageModel m, int messageId)
        {
            Message mg = db.Messages.GetItem(m.MessageId);

            mg.Content = m.Content;
            mg.Sender_Id = m.Sender_Id;
            mg.Recipient_Id = m.Recipient_Id;
            mg.Readed = m.Readed;
            mg.Create_Message = m.Create_Message;
            mg.User = m.User;
            mg.Advert = m.Advert;
            mg.AdvertId = m.AdvertId;
            Save();
        }

        public void DeleteMessage(int id)
        {
            Message m = db.Messages.GetItem(id);
            if (m != null)
            {
                db.Messages.Delete(m.MessageId);
                Save();
            }
        }

        #endregion

        #region CommentReview
        public IEnumerable<Comment_ReviewModel> GetAllComment_Review()
        {
            return db.Comment_Reviews.GetAll().Select(i => new Comment_ReviewModel(i)).ToList();
        }

        public Comment_ReviewModel GetComment_Review(int Id)
        {
            return new Comment_ReviewModel(db.Comment_Reviews.GetItem(Id));
        }

        public void CreateComment_Review(Comment_ReviewModel cr)
        {
            db.Comment_Reviews.Create(new Comment_Review()
            {
                Comment_ReviewId = cr.Comment_ReviewId,
                User = cr.User,
                UserId = cr.UserId,
                Review = cr.Review,
                ReviewId = cr.ReviewId,
                Content = cr.Content,
                Date_of_creation = cr.Date_of_creation
            });
            Save();
        }

        public void UpdateComment_Review(Comment_ReviewModel cr, int comment_reviewId)
        {
            Comment_Review crv = db.Comment_Reviews.GetItem(cr.Comment_ReviewId);
            crv.Comment_ReviewId = cr.Comment_ReviewId;
            crv.User = cr.User;
            crv.UserId = cr.UserId;
            crv.Review = cr.Review;
            crv.ReviewId = cr.ReviewId;
            crv.Content = cr.Content;
            crv.Date_of_creation = cr.Date_of_creation;
            Save();
        }

        public void DeleteComment_Review(int id)
        {
            Comment_Review cr = db.Comment_Reviews.GetItem(id);
            if (cr != null)
            {
                db.Comment_Reviews.Delete(cr.Comment_ReviewId);
                Save();
            }
        }
        #endregion

        #region CommentNews
        public IEnumerable<Comment_NewsModel> GetAllComment_News()
        {
            return db.Comment_News.GetAll().Select(i => new Comment_NewsModel(i)).ToList();
        }

        public Comment_NewsModel GetComment_News(int Id)
        {
            return new Comment_NewsModel(db.Comment_News.GetItem(Id));
        }

        public void CreateComment_News(Comment_NewsModel cn)
        {
            db.Comment_News.Create(new Comment_News()
            {
                Comment_NewsId = cn.Comment_NewsId,
                User = cn.User,
                UserId = cn.UserId,
                News = cn.News,
                NewsId = cn.NewsId,
                Content = cn.Content,
                Date_of_creation = cn.Date_of_creation
            });
            Save();
        }

        public void UpdateComment_News(Comment_NewsModel cn, int comment_newsId)
        {
            Comment_News cns = db.Comment_News.GetItem(cn.Comment_NewsId);
            cns.Comment_NewsId = cn.Comment_NewsId;
            cns.User = cn.User;
            cns.UserId = cn.UserId;
            cns.News = cn.News;
            cns.NewsId = cn.NewsId;
            cns.Content = cn.Content;
            cns.Date_of_creation = cn.Date_of_creation;
            Save();
        }

        public void DeleteComment_News(int id)
        {
            Comment_News cn = db.Comment_News.GetItem(id);
            if (cn != null)
            {
                db.Comment_News.Delete(cn.Comment_NewsId);
                Save();
            }
        }
        #endregion
        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}


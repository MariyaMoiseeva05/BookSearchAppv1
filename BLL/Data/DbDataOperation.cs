using System.Collections.Generic;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
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
            return db.Authors.GetAll().Select(i => new AuthorModel(i)).ToList();
        }

        public AuthorModel GetAuthor(int Id)
        {
            return new AuthorModel(db.Authors.GetItem(Id));
        }

        public void CreateAuthor(AuthorModel a)
        {
            db.Authors.Create(new Author()
            {
                Full_name = a.Full_name,
                Pseudonym = a.Pseudonym,
                Date_of_Birth = a.Date_of_Birth,
                Date_of_Death = a.Date_of_Death,
                Place_of_Birth = a.Place_of_Birth,
                Place_of_Death = a.Place_of_Death,
                Citizenship = a.Citizenship,
                Occupation = a.Occupation,
                Years_of_creativity = a.Years_of_creativity,
                Debut = a.Debut,
                Prizes = a.Prizes,
                Awards = a.Awards,
                Language_of_works = a.Language_of_works,
                ImagePath = a.ImagePath,
                ImageLink = a.ImageLink,
                Book = a.Book,
                Interesting_fact = a.Interesting_fact,
                Details = a.Details
            });
            Save();
        }

        public void UpdateAuthor(AuthorModel a)
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
        public IEnumerable<BookModel> GetAllBooks()
        {
            return db.Books.GetAll().Select(i => new BookModel(i)).ToList();
        }

        public BookModel GetBook(int? Id)
        {
            return new BookModel(db.Books.GetItem(Id));
        }

        public void CreateBook(BookModel b)
        {
            db.Books.Create(new Book()
            {
                AuthorID = b.AuthorID,
                Title = b.Title,
                Description = b.Description,
                Story = b.Story,
                Edition = b.Edition,
                Publication_date = b.Publication_date,
                ImagePath = b.ImagePath,
                ImageLink = b.ImageLink,
                Comment = b.Comment,
                Author = b.Author,
                Screenings = b.Screenings,
                Type_of_literature = b.Type_of_literature,
                Quote = b.Quote,
                Review = b.Review,
                Genre_Books = b.Genre_Books

            });
            Save();
        }

        public void UpdateBook(BookModel b, int? bookId)
        {
            Book bk = db.Books.GetItem(b.BookID);
            bk.AuthorID = b.AuthorID;
            bk.Title = b.Title;
            bk.Description = b.Description;
            bk.Story = b.Story;
            bk.Edition = b.Edition;
            bk.Publication_date = b.Publication_date;
            bk.ImagePath = b.ImagePath;
            bk.ImageLink = b.ImageLink;
            bk.Comment = b.Comment;
            bk.Author = b.Author;
            bk.Screenings = b.Screenings;
            bk.Type_of_literature = b.Type_of_literature;
            bk.Quote = b.Quote;
            bk.Review = b.Review;
            bk.Genre_Books = b.Genre_Books;
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

        #region Comment
        public IEnumerable<CommentModel> GetAllComments()
        {
            return db.Comments.GetAll().Select(i => new CommentModel(i)).ToList();
        }

        public CommentModel GetComment(int Id)
        {
            return new CommentModel(db.Comments.GetItem(Id));
        }

        public void CreateComment(CommentModel c)
        {
            db.Comments.Create(new Comment()
            {
                UserId = c.UserId,
                Content = c.Content,
                Title = c.Title,
                Date_of_creation = c.Date_of_creation,
                BookID = c.BookID,
                Book = c.Book,
                Review = c.Review,
                News = c.News,
                Rating = c.Rating,
                User = c.User
            });
            Save();
        }

        public void UpdateComment(CommentModel c)
        {
            Comment cm = db.Comments.GetItem(c.CommentId);
            cm.UserId = c.UserId;
            cm.BookID = c.BookID;
            cm.Content = c.Content;
            cm.Title = c.Title;
            cm.Date_of_creation = c.Date_of_creation;
            cm.Book = c.Book;
            cm.Rating = c.Rating;
            cm.News = c.News;
            cm.Review = c.Review;
            cm.User = c.User;
            Save();
        }

        public void DeleteComment(int id)
        {
            Comment c = db.Comments.GetItem(id);
            if (c != null)
            {
                db.Comments.Delete(c.CommentId);
                Save();
            }
        }
        #endregion

        #region Genre
        public IEnumerable<GenreModel> GetAllGenres()
        {
            return db.Genres.GetAll().Select(i => new GenreModel(i)).ToList();
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

            }) ;
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
            }) ;
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
            db.Reviews.Create(new Review()
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
        }

        public void UpdateReview(ReviewModel r)
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

        public void UpdateThink(ThinkModel t)
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

        public UserModel GetUser(int Id)
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
                Comment = u.Comment,
                Review = u.Review,
                Think = u.Think,
                Quote = u.Quote
            });
            Save();
        }

        public void UpdateUser(UserModel u)
        {
            User us = db.Users.GetItem(u.UserId);
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
            us.Comment = u.Comment;
            us.Review = u.Review;
            us.Think = u.Think;

            Save();
        }

        public void DeleteUser(int id)
        {
            User u = db.Users.GetItem(id);
            if (u != null)
            {
                db.Users.Delete(u.UserId);
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


using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDbCRUD
    {
        IEnumerable<BookModel> GetAllBooks();
        IEnumerable<AuthorModel> GetAllAuthors();
        IEnumerable<GenreModel> GetAllGenres();
        IEnumerable<Interesting_factModel> GetAllInteresting_facts();
        IEnumerable<NewsModel> GetAllNews();
        IEnumerable<TagModel> GetAllTags();
        IEnumerable<QuoteModel> GetAllQuotes();
        IEnumerable<ReviewModel> GetAllReviews();
        IEnumerable<ThinkModel> GetAllThinks();
        IEnumerable<Type_of_literatureModel> GetAllType_of_literatures();
        IEnumerable<CollectionModel> GetAllCollections();
        IEnumerable<CharacterModel> GetAllCharacters();
        IEnumerable<AdvertModel> GetAllAdverts();
        IEnumerable<Featured_AdvertModel> GetAllFeaturedAdverts();
        IEnumerable<Featured_BookModel> GetAllFeaturedBooks();
        IEnumerable<Like_AdvertModel> GetAllLikeAdverts();
        IEnumerable<LocalityModel> GetAllLocalities();
        IEnumerable<MessageModel> GetAllMessages();
        IEnumerable<Comment_ReviewModel> GetAllComment_Review();
        IEnumerable<Comment_NewsModel> GetAllComment_News();


        AuthorModel GetAuthor(int authorId);
        void CreateAuthor(AuthorModel at);
        void UpdateAuthor(AuthorModel at);
        void DeleteAuthor(int id);

        BookModel GetBook(int bookId);
        void CreateBook(BookModel b);
        void UpdateBook(BookModel b, int bookId);
        void DeleteBook(int id);

        GenreModel GetGenre(int genreId);
        void CreateGenre(GenreModel g);
        void UpdateGenre(GenreModel g);
        void DeleteGenre(int id);

        Interesting_factModel GetInteresting_fact(int interesting_factId);
        void CreateInteresting_fact(Interesting_factModel f);
        void UpdateInteresting_fact(Interesting_factModel f);
        void DeleteInteresting_fact(int id);

        NewsModel GetNews(int newsId);
        void CreateNews(NewsModel n);
        void UpdateNews(NewsModel n);
        void DeleteNews(int id);

        TagModel GetTags(int tagsId);
        void CreateTags(TagModel t);
        void UpdateTags(TagModel t);
        void DeleteTags(int id);


        QuoteModel GetQuote(int quoteId);
        void CreateQuote(QuoteModel q);
        void UpdateQuote(QuoteModel q);
        void DeleteQuote(int id);

        ReviewModel GetReview(int reviewId);
        void CreateReview(ReviewModel r);
        void UpdateReview(ReviewModel r);
        void DeleteReview(int id);

        ThinkModel GetThink(int thinkId);
        void CreateThink(ThinkModel t);
        void UpdateThink(ThinkModel t);
        void DeleteThink(int id);

        Type_of_literatureModel GetType_of_literature(int type_of_literatureId);
        void CreateType_of_literature(Type_of_literatureModel tl);
        void UpdateType_of_literature(Type_of_literatureModel tl);
        void DeleteType_of_literature(int id);

        UserModel GetUser(int userId);
        void CreateUser(UserModel u);
        void UpdateUser(UserModel u);
        void DeleteUser(int id);

        CollectionModel GetCollection(int collectionId);
        void CreateCollection(CollectionModel cl);
        void UpdateCollection(CollectionModel cl);
        void DeleteCollection(int id);

        CharacterModel GetCharacter(int characterId);
        void CreateCharacter(CharacterModel ch);
        void UpdateCharacter(CharacterModel ch);
        void DeleteCharacter(int id);

        AdvertModel GetAdvert(int advertId);
        void CreateAdvert(AdvertModel a);
        void UpdateAdvert(AdvertModel a, int advertId);
        void DeleteAdvert(int id);

        Featured_AdvertModel GetFeaturedAdvert(int featured_advertId);
        void CreateFeaturedAdvert(Featured_AdvertModel fa);
        void UpdateFeaturedAdvert(Featured_AdvertModel fa, int featured_advertId);
        void DeleteFeaturedAdvert(int id);

        Featured_BookModel GetFeaturedBook(int featured_bookId);
        void CreateFeaturedBook(Featured_BookModel fb);
        void UpdateFeaturedBook(Featured_BookModel fb, int featured_bookId);
        void DeleteFeaturedBook(int id);

        Like_AdvertModel GetLikeAdvert(int like_advertId);
        void CreateLikeAdvert(Like_AdvertModel la);
        void UpdateLikeAdvert(Like_AdvertModel la, int like_advertId);
        void DeleteLikeAdvert(int id);

        LocalityModel GetLocality(int localityId);
        void CreateLocality(LocalityModel l);
        void UpdateLocality(LocalityModel l, int localityId);
        void DeleteLocality(int id);

        MessageModel GetMessage(int messageId);
        void CreateMessage(MessageModel m);
        void UpdateMessage(MessageModel m, int messageId);
        void DeleteMessage(int id);

        Comment_ReviewModel GetComment_Review(int comment_reviewId);
        void CreateComment_Review(Comment_ReviewModel cr);
        void UpdateComment_Review(Comment_ReviewModel cr, int comment_reviewId);
        void DeleteComment_Review(int id);

        Comment_NewsModel GetComment_News(int comment_newsId);
        void CreateComment_News(Comment_NewsModel cn);
        void UpdateComment_News(Comment_NewsModel cn, int comment_newsId);
        void DeleteComment_News(int id);

        bool Save();
    }
}



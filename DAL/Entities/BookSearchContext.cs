using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public partial class BookSearchContext : IdentityDbContext<User>
    {
        public BookSearchContext(DbContextOptions<BookSearchContext> options)
            : base(options)
        { }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Think> Thinks { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Genre_Book> Genre_Books { get; set; }
        public virtual DbSet<Interesting_fact> Interesting_Facts { get; set; }
        public virtual DbSet<Type_of_literature> Type_Of_Literatures { get; set; }
        public virtual DbSet<TypeOfLit_Book> TypeOfLit_Books { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<User> PUsers { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Book_Character> Book_Characters { get; set; }
        public virtual DbSet<Book_Collection> Book_Collections { get; set; }
        public virtual DbSet<Author_Book> Author_Books { get; set; }
        public virtual DbSet<Advert> Advert { get; set; }
        public virtual DbSet<Comment_Advert> Comment_Adverts { get; set; }
        public virtual DbSet<Featured_Advert> Featured_Adverts { get; set; }
        public virtual DbSet<Like_Advert> Like_Adverts { get; set; }
        public virtual DbSet<Locality> Localities { get; set; }
        public virtual DbSet<Message> Messages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(b => b.Book)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(b => b.BookID);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(b => b.Book)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(b => b.BookID);
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasOne(b => b.Book)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(b => b.BookID);
            });

            modelBuilder.Entity<Author_Book>()
         .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<Author_Book>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.Authors)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<Author_Book>()
                .HasOne(pt => pt.Author)
                .WithMany(t => t.Book)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<Genre_Book>()
            .HasKey(t => new { t.BookId, t.GenreId });

            modelBuilder.Entity<Genre_Book>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.Genres_Books)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<Genre_Book>()

                .HasOne(pt => pt.Genre)
                .WithMany(t => t.Genre_Books)
                .HasForeignKey(pt => pt.GenreId);

            modelBuilder.Entity<TypeOfLit_Book>()
            .HasKey(t => new { t.BookId, t.TypeId });

            modelBuilder.Entity<TypeOfLit_Book>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.Types_of_literature)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<TypeOfLit_Book>()

                .HasOne(pt => pt.TypeLit)
                .WithMany(t => t.Book)
                .HasForeignKey(pt => pt.TypeId);

            modelBuilder.Entity<News_Tags>()
           .HasKey(t => new { t.NewsId, t.TagId });

            modelBuilder.Entity<News_Tags>()
                .HasOne(pt => pt.News)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.NewsId);

            modelBuilder.Entity<News_Tags>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.News)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(b => b.UserId);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(p => p.Review)
                    .HasForeignKey(b => b.UserID);
            });

            modelBuilder.Entity<Think>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(p => p.Think)
                    .HasForeignKey(b => b.UserId);
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(p => p.Quote)
                    .HasForeignKey(b => b.UserID);
            });

            modelBuilder.Entity<Book_Character>()
            .HasKey(t => new { t.BookId, t.CharacterId });

            modelBuilder.Entity<Book_Character>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.Book_Characters)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<Book_Character>()
                .HasOne(pt => pt.Character)
                .WithMany(t => t.Book_Characters)
                .HasForeignKey(pt => pt.CharacterId);

            modelBuilder.Entity<Book_Collection>()
            .HasKey(t => new { t.BookId, t.CollectionId });

            modelBuilder.Entity<Book_Collection>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.Book_Collections)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<Book_Collection>()
                .HasOne(pt => pt.Collection)
                .WithMany(t => t.Book_Collections)
                .HasForeignKey(pt => pt.CollectionId);

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(p => p.Message)
                    .HasForeignKey(b => b.Recipient_Id);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(p => p.Message)
                    .HasForeignKey(b => b.Sender_Id);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(b => b.Advert)
                    .WithMany(p => p.Message)
                    .HasForeignKey(b => b.AdvertId);
            });


            modelBuilder.Entity<Comment_Advert>(entity =>
            {
                entity.HasOne(b => b.Advert)
                    .WithMany(p => p.Comment_Advert)
                    .HasForeignKey(b => b.AdvertId);
            });

            modelBuilder.Entity<Comment_Advert>(entity =>
            {
                entity.HasOne(b => b.User)
                    .WithMany(p => p.Comment_Advert)
                    .HasForeignKey(b => b.UserId);
            });

            modelBuilder.Entity<Featured_Advert>()
           .HasKey(t => new { t.AdvertId, t.UserId });

            modelBuilder.Entity<Featured_Advert>()
                .HasOne(pt => pt.Advert)
                .WithMany(p => p.Featured_Adverts)
                .HasForeignKey(pt => pt.AdvertId);

            modelBuilder.Entity<Featured_Advert>()
                .HasOne(pt => pt.User)
                .WithMany(t => t.Featured_Adverts)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<Like_Advert>()
           .HasKey(t => new { t.AdvertId, t.UserId });

            modelBuilder.Entity<Like_Advert>()
                .HasOne(pt => pt.Advert)
                .WithMany(p => p.Like_Adverts)
                .HasForeignKey(pt => pt.AdvertId);

            modelBuilder.Entity<Like_Advert>()
                .HasOne(pt => pt.User)
                .WithMany(t => t.Like_Adverts)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<Advert>(entity =>
            {
                entity.HasOne(b => b.Book)
                    .WithMany(p => p.Adverts)
                    .HasForeignKey(b => b.BookId);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class BookSearchContext : DbContext
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
        public virtual DbSet<Genre_Author> Genre_Authors { get; set; }
        public virtual DbSet<Genre_TypeLit> Genre_TypeLiters { get; set; }
        public virtual DbSet<Interesting_fact> Interesting_Facts { get; set; }
        public virtual DbSet<Type_of_literature> Type_Of_Literatures { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }

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
                    .WithMany(p => p.Comment)
                    .HasForeignKey(b => b.BookID);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(b => b.Book)
                    .WithMany(p => p.Review)
                    .HasForeignKey(b => b.BookID);
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasOne(b => b.Book)
                    .WithMany(p => p.Quote)
                    .HasForeignKey(b => b.BookID);
            });

            modelBuilder.Entity<Genre_Book>()
            .HasKey(t => new { t.BookId, t.GenreId });

            modelBuilder.Entity<Genre_Book>()
                .HasOne(pt => pt.Book)
                .WithMany(p => p.Genre_Books)
                .HasForeignKey(pt => pt.BookId);

            modelBuilder.Entity<Genre_Book>()

                .HasOne(pt => pt.Genre)
                .WithMany(t => t.Genre_Books)
                .HasForeignKey(pt => pt.GenreId);

            modelBuilder.Entity<Genre_Author>()
            .HasKey(t => new { t.AuthorId, t.GenreId });

            modelBuilder.Entity<Genre_Author>()
                .HasOne(pt => pt.Author)
                .WithMany(p => p.Genre)
                .HasForeignKey(pt => pt.AuthorId);

            modelBuilder.Entity<Genre_Author>()

                .HasOne(pt => pt.Genre)
                .WithMany(t => t.Author)
                .HasForeignKey(pt => pt.GenreId);

            modelBuilder.Entity<Genre_TypeLit>()
            .HasKey(t => new { t.TypeLitId, t.GenreId });

            modelBuilder.Entity<Genre_TypeLit>()
                .HasOne(pt => pt.Type_of_literature)
                .WithMany(p => p.Genres)
                .HasForeignKey(pt => pt.TypeLitId);

            modelBuilder.Entity<Genre_TypeLit>()

                .HasOne(pt => pt.Genre)
                .WithMany(t => t.Type_of_literature)
                .HasForeignKey(pt => pt.GenreId);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(b => b.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(b => b.AuthorID);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasOne(b => b.Type_of_literature)
                    .WithMany(p => p.Book)
                    .HasForeignKey(b => b.Type_of_literatureId);
            });

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

            /*modelBuilder.Entity<Comment>(entity =>
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
            });*/
        }
    }
}

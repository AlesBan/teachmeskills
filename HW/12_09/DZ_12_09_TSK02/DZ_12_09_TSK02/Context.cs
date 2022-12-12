using System.Linq;
using Bogus;
using DZ_12_09_TSK02.Models;
using Microsoft.EntityFrameworkCore;

namespace DZ_12_09_TSK02
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasKey(b => b.BookId);
            modelBuilder.Entity<Book>()
                .Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Author>()
                .HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>()
                .Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Author>()
                .Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(40);

            modelBuilder.Entity<UserBook>()
                .HasKey(us => us.UserBookId);

            modelBuilder.Entity<UserBook>()
                .HasOne(us => us.Book)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(us => us.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserBook>()
                .HasOne(us => us.User)
                .WithMany(b => b.UserBooks)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //seeding
            var authors = Author.Generate(100);
            var users = User.Generate(30);
            var books = Book.Generate(100, authors.Select(x => x.AuthorId).ToArray()).ToArray();

            var userbooks = UserBook.Generate(100, 
                users.Select(x => x.UserId).ToArray(), 
                books.Select(x => x.BookId).ToArray()).ToArray();
            
            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<UserBook>().HasData(userbooks);
            

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SqlPracticeDB;Integrated Security=true;");
        }
    }
}
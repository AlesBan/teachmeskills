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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SqlPracticeDB;Integrated Security=true;");
        }


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
        }
    }
}
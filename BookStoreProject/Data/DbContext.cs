using BookStoreProject.Models;
using Microsoft.EntityFrameworkCore;


namespace BookStoreProject.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                 .Property(b => b.Price)
                 .HasPrecision(18, 2); // Precision: 18 digits, 2 after the decimal

            base.OnModelCreating(modelBuilder);
        }
    }
}
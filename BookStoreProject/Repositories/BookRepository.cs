using BookStoreProject.Data;
using BookStoreProject.DTOs;
using BookStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _context;

        public BookRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Select(b => new BookDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price,
                    PublicationDate = b.PublicationDate,
                    AuthorName = b.Author.Name,
                    AuthorId = b.Author.Id,
                    CategoryName = b.Category.Name,
                    CategoryId = b.Category.Id,
                })
                .ToListAsync();

            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
           var bookById = await _context.Books.Include( x=> x.Author)
                        .Include(x => x.Category)
                        .FirstOrDefaultAsync(x=> x.Id == id);

            if (bookById == null) throw new Exception("Book not found");
            
            return bookById;
        }

        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}

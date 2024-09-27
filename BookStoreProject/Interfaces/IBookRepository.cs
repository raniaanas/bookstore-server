using BookStoreProject.DTOs;
using BookStoreProject.Models;

namespace BookStoreProject.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);  
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}

using BookStoreProject.DTOs;
using BookStoreProject.Models;

namespace BookStoreProject.Services
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}

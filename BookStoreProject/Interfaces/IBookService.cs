using BookStoreProject.Models;

namespace BookStoreProject.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}

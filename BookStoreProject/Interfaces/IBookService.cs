using BookStoreProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreProject.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);  // Add this method
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}

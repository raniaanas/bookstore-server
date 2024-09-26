using BookStoreProject.Models;

namespace BookStoreProject.Services

{
    public interface IAuthorService 
    {
        Task<IEnumerable<Author>> GetAllAuthors();

        Task<Author> GetAuthorById(int id);
    }
}

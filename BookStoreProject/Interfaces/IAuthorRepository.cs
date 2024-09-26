using BookStoreProject.Models;

namespace BookStoreProject.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
    }
}

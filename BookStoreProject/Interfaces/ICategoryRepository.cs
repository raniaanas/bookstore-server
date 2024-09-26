using BookStoreProject.Models;

namespace BookStoreProject.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
    }
}

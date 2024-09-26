using BookStoreProject.Models;

namespace BookStoreProject.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();

        Task<Category> GetCategoryById(int id);
    }
}

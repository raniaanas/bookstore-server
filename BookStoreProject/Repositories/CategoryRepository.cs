using BookStoreProject.Data;
using BookStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookstoreDbContext _context;

        public CategoryRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}

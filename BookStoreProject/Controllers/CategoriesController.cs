using BookStoreProject.DTOs;
using BookStoreProject.Models;
using BookStoreProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            }));
        }

        // GET: api/category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if(category == null) return NotFound();

            var categoryDTO = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
             
            };
            return Ok(categoryDTO);
        }
    }
}

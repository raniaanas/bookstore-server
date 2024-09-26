using BookStoreProject.DTOs;
using BookStoreProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            return Ok(authors.Select(author => new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name
            }));
        }

        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var author = await _authorService.GetAuthorById(id);

            if (author == null) return NotFound();

            var authorDTO = new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name,
            };

            return Ok(authorDTO);
        }
    }
}

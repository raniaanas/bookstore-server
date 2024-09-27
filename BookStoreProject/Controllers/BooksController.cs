using BookStoreProject.DTOs;
using BookStoreProject.Models;
using BookStoreProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        // Inject ILogger in the constructor
        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {   
            var book = await _bookService.GetBookById(id);

            if (book == null) return NotFound();

            var bookDTO = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                AuthorName = book.Author?.Name,
                CategoryName = book.Category?.Name,
                Price = book.Price ?? 0,
                PublicationDate = book.PublicationDate ?? DateTime.Now
            };

            return Ok(bookDTO);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] Book book)
        {
            try
            {
                _logger.LogInformation("Adding a new book with title: {title}", book.Title);
                await _bookService.AddBook(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a new book");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                _logger.LogWarning("Book ID in request body does not match URL parameter: {id}", id);
                return BadRequest();
            }

            try
            {
                _logger.LogInformation("Updating book with ID {id}", id);
                await _bookService.UpdateBook(book);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating book with ID {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                _logger.LogInformation("Deleting book with ID {id}", id);
                await _bookService.DeleteBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting book with ID {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

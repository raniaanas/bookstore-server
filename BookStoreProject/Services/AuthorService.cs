using BookStoreProject.Models;
using BookStoreProject.Repositories;


namespace BookStoreProject.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _authorRepository.GetAuthorById(id);
        }
    }
}

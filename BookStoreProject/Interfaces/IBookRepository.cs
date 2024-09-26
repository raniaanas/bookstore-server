﻿using BookStoreProject.Models;

namespace BookStoreProject.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);  
        Task UpdateBook(Book book);
        Task DeleteBook(int id);
    }
}

using LibraryManagement.Server.Models;
using LibraryManagement.Server.Repositories.Interfaces;
using LibraryManagement.Server.Services.Interfaces;

namespace LibraryManagement.Server.Services
{
    public class BookService(IBookRepository repository) : IBookService
    {
        public Task<IEnumerable<Book>> GetBooksAsync() => repository.GetAllAsync();
        public Task<Book?> GetBookAsync(int id) => repository.GetByIdAsync(id);
        public Task AddBookAsync(Book book) => repository.AddAsync(book);
        public Task DeleteBookAsync(int id) => repository.RemoveAsync(id);
        public Task<IEnumerable<Book>> SearchBooksAsync(string keyword) =>
            repository.SearchAsync(keyword);
    }
}

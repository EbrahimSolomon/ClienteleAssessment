using LibraryManagement.Server.Models;

namespace LibraryManagement.Server.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task RemoveAsync(int id);
        Task<IEnumerable<Book>> SearchAsync(string keyword);
    }
}

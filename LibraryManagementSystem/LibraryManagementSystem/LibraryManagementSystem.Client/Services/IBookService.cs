using LibraryManagementSystem.Client.Models;

namespace LibraryManagementSystem.Client.Services;

public interface IBookService
{
    Task<List<BookDto>> GetBooksAsync();
    Task AddBookAsync(BookDto book);
    Task DeleteBookAsync(int id);
    Task<List<BookDto>> SearchBooksAsync(string query);
}

using LibraryManagementSystem.Dtos;

namespace LibraryManagementSystem.Services;

public interface IBookService
{
    Task<IEnumerable<BookDto>> GetBooksAsync();
    Task<BookDto?> GetBookByIdAsync(int id);
    Task AddBookAsync(BookDto bookDto);
    Task DeleteBookAsync(int id);
    Task<IEnumerable<BookDto>> SearchBooksAsync(string query);
}

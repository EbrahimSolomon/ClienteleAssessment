using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services;

public class BookService(IBookRepository repo) : IBookService
{
    public async Task<IEnumerable<BookDto>> GetBooksAsync() =>
        (await repo.GetAllAsync()).Select(MapToDto);

    public async Task<BookDto?> GetBookByIdAsync(int id)
    {
        var book = await repo.GetByIdAsync(id);
        return book == null ? null : MapToDto(book);
    }

    public Task AddBookAsync(BookDto bookDto)
        => repo.AddAsync(new Book
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
            PublicationYear = bookDto.PublicationYear
        });

    public Task DeleteBookAsync(int id)
        => repo.DeleteAsync(id);

    public async Task<IEnumerable<BookDto>> SearchBooksAsync(string query) =>
        (await repo.SearchAsync(query)).Select(MapToDto);

    private static BookDto MapToDto(Book book) => new()
    {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        ISBN = book.ISBN,
        PublicationYear = book.PublicationYear
    };
}

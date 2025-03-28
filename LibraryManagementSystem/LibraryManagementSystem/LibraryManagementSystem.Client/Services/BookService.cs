using LibraryManagementSystem.Client.Models;
using System.Net.Http.Json;

namespace LibraryManagementSystem.Client.Services;

public class BookService(HttpClient http) : IBookService
{
    public Task<List<BookDto>> GetBooksAsync() =>
        http.GetFromJsonAsync<List<BookDto>>("api/books")!;

    public Task AddBookAsync(BookDto book) =>
        http.PostAsJsonAsync("api/books", book);

    public Task DeleteBookAsync(int id) =>
        http.DeleteAsync($"api/books/{id}");

    public Task<List<BookDto>> SearchBooksAsync(string query) =>
        http.GetFromJsonAsync<List<BookDto>>($"api/books/search/{query}")!;
}

using System.Net.Http.Json;
using LibraryManagement.Shared.DTOs;

namespace LibraryManagement.Website.Services;

public class BookApiService(HttpClient httpClient)
{
    public async Task<List<BookDto>?> GetBooksAsync() =>
        await httpClient.GetFromJsonAsync<List<BookDto>>("api/books");

    public async Task AddBookAsync(BookDto book) =>
        await httpClient.PostAsJsonAsync("api/books", book);

    public async Task DeleteBookAsync(int id) =>
        await httpClient.DeleteAsync($"api/books/{id}");

    public async Task<List<BookDto>?> SearchBooksAsync(string keyword) =>
        await httpClient.GetFromJsonAsync<List<BookDto>>($"api/books/search/{keyword}");
}

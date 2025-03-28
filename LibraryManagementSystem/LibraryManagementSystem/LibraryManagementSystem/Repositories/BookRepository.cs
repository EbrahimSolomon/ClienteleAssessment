using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories;

public class BookRepository(ApplicationDbContext context) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetAllAsync() =>
        await context.Books.ToListAsync();

    public async Task<Book?> GetByIdAsync(int id) =>
        await context.Books.FindAsync(id);

    public async Task AddAsync(Book book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book != null)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Book>> SearchAsync(string query) =>
        await context.Books
            .Where(b => b.Title.Contains(query) || b.Author.Contains(query))
            .ToListAsync();
}

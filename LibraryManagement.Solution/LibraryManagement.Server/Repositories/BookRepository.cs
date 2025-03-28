using LibraryManagement.Server.Data;
using LibraryManagement.Server.Models;
using LibraryManagement.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Server.Repositories
{
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

        public async Task RemoveAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> SearchAsync(string keyword) =>
            await context.Books
                .Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword))
                .ToListAsync();
    }
}
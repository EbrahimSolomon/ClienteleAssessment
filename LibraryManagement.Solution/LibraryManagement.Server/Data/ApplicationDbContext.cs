using LibraryManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Server.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : DbContext(options)
    {
        public DbSet<Book> Books { get; set; } = null!;
    }
}

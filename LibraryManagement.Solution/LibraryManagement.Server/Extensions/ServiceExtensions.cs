using LibraryManagement.Server.Repositories.Interfaces;
using LibraryManagement.Server.Repositories;
using LibraryManagement.Server.Services.Interfaces;
using LibraryManagement.Server.Services;

namespace LibraryManagement.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services) =>
            services.AddScoped<IBookRepository, BookRepository>();

        public static void ConfigureServices(this IServiceCollection services) =>
            services.AddScoped<IBookService, BookService>();
    }
}

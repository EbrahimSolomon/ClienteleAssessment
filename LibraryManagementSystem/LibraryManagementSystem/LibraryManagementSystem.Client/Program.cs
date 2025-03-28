using LibraryManagementSystem.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IBookService, BookService>();

await builder.Build().RunAsync();

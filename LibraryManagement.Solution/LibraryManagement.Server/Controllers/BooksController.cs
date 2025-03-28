using LibraryManagement.Server.Models;
using LibraryManagement.Server.Services.Interfaces;
using LibraryManagement.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _service.GetBooksAsync();

            var booksDto = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                PublicationYear = b.PublicationYear
            });

            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _service.GetBookAsync(id);
            if (book is null)
                return NotFound();

            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear
            };

            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                PublicationYear = bookDto.PublicationYear
            };

            await _service.AddBookAsync(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, bookDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _service.DeleteBookAsync(id);
            return NoContent();
        }

        [HttpGet("search/{keyword}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> SearchBooks(string keyword)
        {
            var books = await _service.SearchBooksAsync(keyword);

            var booksDto = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                PublicationYear = b.PublicationYear
            });

            return Ok(booksDto);
        }
    }
}

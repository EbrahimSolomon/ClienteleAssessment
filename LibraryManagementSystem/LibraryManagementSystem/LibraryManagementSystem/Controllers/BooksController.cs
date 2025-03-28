using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await service.GetBooksAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var book = await service.GetBookByIdAsync(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookDto bookDto)
    {
        await service.AddBookAsync(bookDto);
        return CreatedAtAction(nameof(Get), new { id = bookDto.Id }, bookDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await service.DeleteBookAsync(id);
        return NoContent();
    }

    [HttpGet("search/{query}")]
    public async Task<IActionResult> Search(string query) =>
        Ok(await service.SearchBooksAsync(query));
}

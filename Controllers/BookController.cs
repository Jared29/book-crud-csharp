using BookApi.Models;
using BookApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    public BookController()
    {

    }

    // GET all books
    [HttpGet]
    public ActionResult<List<Book>> GetAll() =>
        BookService.GetAll();

    // GET specific book
    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = BookService.Get(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    // CREATE new book
    [HttpPost]
    public IActionResult Create(Book book){
        BookService.Add(book);
        return CreatedAtAction(nameof(Create), new { id = book.Id }, book);
    }

    // UPDATE specific book
    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book){
        if(id != book.Id){
            return BadRequest();
        }

        var existingBook = BookService.Get(id);
        if(existingBook is null){
            return NotFound();
        }

        BookService.Update(book);

        return NoContent();
    }

    // DELETE specific book
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var book = BookService.Get(id);

        if(book is null){
            return NotFound();
        }

        BookService.Delete(id);

        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
using Bookstore.Interfaces;
using Bookstore.Data;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
    private readonly IBookRepository _bookRepository;
    private readonly DataContext _context;

    public BookController(IBookRepository bookRepository, DataContext context)
    {
      _bookRepository = bookRepository;
      _context = context;
    }

        // Retrieve all books
        [HttpGet("")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(books);
        }

        // Retrieve a book
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(400)]
        public IActionResult GetBook(int id)
        {
            if(!_bookRepository.BookExists(id)) return NotFound();
            var book = _bookRepository.GetBook(id);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(book);
        }

        // Create a book
        [HttpPost("")]
        [ProducesResponseType(204)]     
        [ProducesResponseType(400)] 
        public IActionResult AddBook(Book book)
        {
          if(book == null) return BadRequest(ModelState);
          if(!ModelState.IsValid) return BadRequest(ModelState);
          _bookRepository.CreateBook(book);
          return Ok("Successfully created book.");
        }

        // Update a book
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateBook(int id, [FromBody]Book book)
        {
          if(book == null) return BadRequest(ModelState);
          if(id != book.Id) return BadRequest(ModelState);
          if(!_bookRepository.BookExists(id)) return NotFound();
          if(!ModelState.IsValid) return BadRequest(ModelState);
          _bookRepository.UpdateBook(book);
          return NoContent();
        }

        // Delete a book
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBook(int id)
        {
          if(!_bookRepository.BookExists(id)) return NotFound();
          var bookToDelete = _bookRepository.GetBook(id);
          if(!ModelState.IsValid) return BadRequest(ModelState);
          _bookRepository.DeleteBook(bookToDelete);
          return NoContent();
        }
    }
}
using Bookstore.Data;
using Bookstore.Interfaces;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ComicController : Controller
  {
    private readonly IComicRepository _comicRepository;
    private readonly DataContext _context;

    public ComicController(IComicRepository comicRepository, DataContext context)
    {
      _comicRepository = comicRepository;
      _context = context;
    }
    [HttpGet("")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Comic>))]
    public IActionResult GetComics()
    {
      var comics = _comicRepository.GetComics();
      if(!ModelState.IsValid) return BadRequest(ModelState);
      return Ok(comics);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Comic))]
    [ProducesResponseType(400)]
    public IActionResult GetComic(int id)
    {
      if(!_comicRepository.ComicExists(id)) return NotFound();
      var comic = _comicRepository.GetComic(id);
      if(!ModelState.IsValid) return BadRequest(ModelState);
      return Ok(comic);
    }
    
    [HttpPost("")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateComic([FromBody]Comic comic)
    {
      if(comic == null) return BadRequest(ModelState);
      if(!ModelState.IsValid) return BadRequest(ModelState);
      _comicRepository.CreateComic(comic);
      return Ok("Successfully created comic.");
    }

    [HttpPut("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateComic(int id,[FromBody]Comic comic)
    {
      if(comic == null) return BadRequest(ModelState);
      if(id != comic.Id) return BadRequest(ModelState);
      if(!_comicRepository.ComicExists(id)) return BadRequest(ModelState);
      if(!ModelState.IsValid) return BadRequest(ModelState);
      _comicRepository.UpdateComic(comic);
      return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteBook(int id)
    {
      if(!_comicRepository.ComicExists(id)) return NotFound();
      var comicToDelete = _comicRepository.GetComic(id);
      if(!ModelState.IsValid) return BadRequest(ModelState);
      _comicRepository.DeleteComic(comicToDelete);
      return NoContent();
    }
  }
}
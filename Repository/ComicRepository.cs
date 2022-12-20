using Bookstore.Data;
using Bookstore.Interfaces;
using Bookstore.Models;

namespace Bookstore.Repository
{
  public class ComicRepository : IComicRepository
  {
    private readonly DataContext _context;

    public ComicRepository(DataContext context)
    {
      _context = context;
    }
    public ICollection<Comic> GetComics()
    {
      return _context.Comics.OrderBy(p => p.Id).ToList();
    }
    public bool ComicExists(int id)
    {
      return _context.Comics.Any(p => p.Id == id);
    }
    public Comic GetComic(int id)
    {
      return _context.Comics.Where(p => p.Id == id).FirstOrDefault();
    }
    public bool CreateComic(Comic comic)
    {
      _context.Add(comic);
      return Save();

    }
    public bool UpdateComic(Comic comic)
    {
      _context.Update(comic);
      return Save();
    }
    public bool DeleteComic(Comic comic)
    {
      _context.Remove(comic);
      return Save();
    }
    public bool Save()
    {
      var saved =_context.SaveChanges();
      return saved > 0 ? true : false;
    }
  }
}
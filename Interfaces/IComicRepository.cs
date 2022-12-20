using Bookstore.Models;

namespace Bookstore.Interfaces
{
  public interface IComicRepository
  {
    ICollection<Comic> GetComics();
    bool ComicExists(int id);
    Comic GetComic(int id);
    bool CreateComic(Comic comic);
    bool UpdateComic(Comic comic);
    bool DeleteComic(Comic comic);
    bool Save();
  }
}
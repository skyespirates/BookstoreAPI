using Bookstore.Data;
using Bookstore.Models;

namespace Bookstore
{
    public class Seed
    {
      private readonly DataContext dataContext;

      public Seed(DataContext context)
      {
        dataContext = context;
      }
      public void SeedDataContext()
      {
        if(!dataContext.Books.Any())
        {
          var books = new List<Book>() {
            new Book(){
            Title = "Pulang",
            Author = "Tere Liye",
            ReleaseDate = new DateTime(2004, 2, 3),
            Quantity = 64,
            },
            new Book(){
            Title = "Pergi",
            Author = "Tere Liye",
            ReleaseDate = new DateTime(2005, 6, 10),
            Quantity = 32,
            },
            new Book(){
            Title = "Pulang-Pergi",
            Author = "Tere Liye",
            ReleaseDate = new DateTime(2006, 12, 30),
            Quantity = 81,
            },
          };
          dataContext.Books.AddRange(books);      
        }
        if(!dataContext.Comics.Any())
        {
          var comics = new List<Comic>() {
            new Comic() {
              Title = "One Piece",
              Author = "Eichiro Oda",
              Chapter = 1069,
              IsFinished = false,
              Quantity = 64,
            },
            new Comic() {
              Title = "Naruto",
              Author = "Masashi Kishimoto",
              Chapter = 700,
              IsFinished = true,
              Quantity = 16,
            },
            new Comic() {
              Title = "Shingeki No Kyojin",
              Author = "Hajime Isayama",
              Chapter = 139,
              IsFinished = true,
              Quantity = 24,
            },
            new Comic() {
              Title = "One Punch-Man",
              Author = "One & Yusuke Murata",
              Chapter = 176,
              IsFinished = false,
              Quantity = 72,
            },
          };
        dataContext.Comics.AddRange(comics);
        }
        dataContext.SaveChanges();
      }
    }
}
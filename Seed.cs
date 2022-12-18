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
          dataContext.SaveChanges();
        }
      }
    }
}
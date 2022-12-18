namespace Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }   
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Quantity { get; set; }

    }
}
namespace Bookstore.Models
{
  public class Comic
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Chapter { get; set; }
    public bool IsFinished { get; set; }
    public int Quantity { get; set; }
  }
}
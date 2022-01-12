using System.ComponentModel.DataAnnotations;

namespace Entidad;
public class Book
{
    [Key]
    public int BookId { get; set; }
    public string BookTittle { get; set; }
    public string PublisherName { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }
    public int State { get; set; }
}

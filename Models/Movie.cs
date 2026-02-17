using System.ComponentModel.DataAnnotations;
public class Movie
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    [Display(Name = "Name")]
    public string Name { get; set; }= string.Empty;
    [Display(Name = "Genre")]
    public int GenreId { get; set; }

    [Display(Name = "Genre")]
    public Genre Genre { get; set; }=new Genre();

    public ICollection<Customer> Customers { get; set; }= new List<Customer>();
}
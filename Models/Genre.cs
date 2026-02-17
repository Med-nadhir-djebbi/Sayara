using System.ComponentModel.DataAnnotations;

public class Genre
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    [Display(Name = "Genre Name")]
    public string Name { get; set; }=string.Empty;

    public ICollection<Movie> Movies { get; set; }=new List<Movie> ();
}

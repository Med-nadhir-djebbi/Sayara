public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public int? MembershipTypeId { get; set; }
    public MembershipType? Membership { get; set; }
    public ICollection<Movie> Movies { get; set; }= new List<Movie>();
}
public class MembershipType
{
    public int Id {get;set;}
    public string Name { get; set; } = string.Empty;
    public double SignUpFee{get;set;}
    public int DurationInMonth {get;set;}
    public int DiscountRate {get;set;}
    public  ICollection<Customer>? Customers {get;set;}
}
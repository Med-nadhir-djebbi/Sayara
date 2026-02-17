using System.Diagnostics;
namespace tpFINAL.Models;
public class CustomerViewModel
{
    public int Id {get;set;}
    public string Name {get;set;}=string.Empty;
    public int DiscountRate {get;set;}
}
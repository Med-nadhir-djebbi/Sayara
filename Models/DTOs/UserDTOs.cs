namespace Sayara.Models.DTOs{

public class RegisterDTO
{
    public String FirstName {get;set;}
    public String LastName {get;set;}
    public String Email {get;set;}
    public int PhoneNumber {get;set;}
    public String Password {get; set;}
    public String ConfirmePassword {get ; set;}

}
public class UserProfileDTO
{
    public int Id { get ; set;}
    public String FirstName {get;set;}
    public String LastName {get;set;}
    public String Email {get;set;}
    public int PhoneNumber {get;set;}  
    public String Role { get; set;}
    public DateTime CreatedAt {get;set;}

}
public class LoginDTO
{
    public String Email {get;set;} 
    public String Password{get ; set;}

}
}
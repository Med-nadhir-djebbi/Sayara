namespace Sayara.Models.DTOs{

public class RegisterDTO
{
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Email {get;set;}
    public int PhoneNumber {get;set;}
    public string Password {get; set;}
    public string ConfirmePassword {get ; set;}

}
public class UserProfileDTO
{
    public int Id { get ; set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Email {get;set;}
    public int PhoneNumber {get;set;}  
    public string Role { get; set;}
    public DateTime CreatedAt {get;set;}

}
public class LoginDTO
{
    public string Email {get;set;} 
    public string Password{get ; set;}

}
}
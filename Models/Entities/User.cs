using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace Sayara.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public String FirstName {get;set;}
        public String LastName {get;set;}
        public String Email {get;set;}
        public int PasswordHash {get;set;}
        public int PhoneNumber {get;set;}
        public String Role {get;set;}
        public DateTime CreatedAt {get;set;}=DateTime.Now;
        public bool IsActive {get;set;}
    }
}
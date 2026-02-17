using Microsoft.AspNetCore.Identity;

namespace tpFINAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}

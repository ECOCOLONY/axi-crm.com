using Microsoft.AspNetCore.Identity;

namespace Base.WebUI.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace GreenHost.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
